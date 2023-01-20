using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    // public Vector2 projectileSpawnPosition;
    public LayerMask shieldLayerMask;
    public LayerMask playerLayerMask;
    public LayerMask wallLayerMask;
    public GameObject projectilePrefab;
    public float speed = 1f;
    public float deflectionSpeed = 2f;
    float distanceBeforeDetection = 0.1f;
    float distanceFromSelfHitbox = 0.143f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        // Move projectile forward
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        // Deflect method
        RaycastHit2D hitShield = Physics2D.Raycast(transform.position + transform.right * distanceFromSelfHitbox, transform.right, distanceBeforeDetection, shieldLayerMask);
        if (hitShield.collider != null)
        {
            Vector2 reflectDir = Vector2.Reflect(transform.right, hitShield.normal);
            float rot = Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, rot);
            rb.freezeRotation = true;
            speed *= deflectionSpeed;
            // ENTER THE ANIMATION MODE (pause and wait for animation before the ricochet!)
        }

        // Damage player and destroy projectile
        RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position + transform.right * distanceFromSelfHitbox, transform.right, distanceBeforeDetection, playerLayerMask);
        if (hitPlayer.collider != null)
        {
            float currentPlayerHealth = hitPlayer.collider.transform.GetComponent<PlayerStats>().health;
            currentPlayerHealth -= 0.4f;

            if (currentPlayerHealth >= 0f) // deal damage to player
            {
                hitPlayer.collider.transform.GetComponent<PlayerStats>().SetHealth(currentPlayerHealth);
            }
            else
            {
                hitPlayer.collider.transform.GetComponent<PlayerStats>().SetHealth(0);
                hitPlayer.collider.transform.GetComponent<PlayerStats>().DecrementStock();
            }
            Destroy(gameObject);
        }

        // Destroy projectile upon hitting wall
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position + transform.right * distanceFromSelfHitbox, transform.right, distanceBeforeDetection, wallLayerMask);
        if (hitWall.collider != null)
        {
            Destroy(gameObject);
        }

        // if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1f, collisionMask))
        // {
            // Debug.Log("Hi");
            // Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            // float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            // transform.eulerAngles = new Vector3(0,0,rot);
        // }
    }

    // void OnCollisionEnter2D(Collision2D col) {
    //     RaycastHit2D hit = Physics

    //     if (col.gameObject.tag != "Shield") {
    //         Destroy(gameObject);
    //     }
    //     else if (col.gameObject.tag != "Player")
    //     {
    //         Destroy(gameObject);
    //         // deal player dmg
    //     }
    // }

}