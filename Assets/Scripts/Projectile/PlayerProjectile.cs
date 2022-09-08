using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    // public Vector2 projectileSpawnPosition;
    public LayerMask collisionMask;
    public GameObject projectilePrefab;
    public float speed = 1f;
    public float deflectionSpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        // Move projectile forward
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        // Deflect method
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right * 0.143f, transform.right, 0.2f, collisionMask);
        if (hit.collider != null)
        {
            Vector2 reflectDir = Vector2.Reflect(transform.right, hit.normal);
            float rot = Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, rot);
            rb.freezeRotation = true;
            speed *= deflectionSpeed;
            // ENTER THE ANIMATION MODE (pause and wait for animation before the ricochet!)
        }
        
        // if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1f, collisionMask))
        // {
            // Debug.Log("Hi");
            // Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            // float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            // transform.eulerAngles = new Vector3(0,0,rot);
        // }
    }

    // void OnCollisionEnter2D(Collision2D col){
    //     if (col.gameObject.tag == "Shield") {

    //         rb.AddForce(projectileSpawnPosition * 15f, ForceMode2D.Impulse);

    //         Vector2 newProjectileSpawnPosition = transform.position;
    //         GameObject projectile = Instantiate(projectilePrefab, transform);
    //         projectile.GetComponent<PlayerProjectile>().projectileSpawnPosition = newProjectileSpawnPosition;
    //         Rigidbody2D newRb = projectile.GetComponent<Rigidbody2D>();
    //         rb.AddForce(projectileSpawnPosition * 10f, ForceMode2D.Impulse);
    //         rb.freezeRotation = true;

    //         // Debug.Log("Points colliding: " + col.contacts.Length);
    //         // Debug.Log("First contact point: " + col.GetContact(0).point);
            
    //         // // // Print how many points are colliding with this transform
    //         // // Debug.Log("Points colliding: " + col.contacts.Length);

    //         // // // Print the normal of the first point in the collision.
    //         // Debug.Log("Normal of the first point: " + col.contacts[0].normal);

    //         // // // Draw a different colored ray for every normal in the collision
    //         // // foreach (var item in col.contacts)
    //         // // {
    //         // //     Debug.DrawRay(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
    //         // // }
    //         // rb.AddForce (transform.right * projectileForce, ForceMode2D.Impulse);
    //         // Vector3 v = Vector3.Reflect(transform.right, col.contacts[0].normal);
    //         // float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
    //         // transform.eulerAngles = new Vector3(0, 0, rot);
    //     }
    //     else if (col.gameObject.tag != "Player")
    //     {
    //         Destroy(gameObject);
    //     }
    // }

}