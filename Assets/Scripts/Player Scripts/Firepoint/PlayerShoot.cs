using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float projectileForce = 20f;
    float playerToProjectileAlignment = 1.2f;

    public void Shoot()
    {
        // Vector2 projectileSpawnPosition = firePoint.position + firePoint.right * playerToProjectileAlignment;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position + firePoint.right * playerToProjectileAlignment, firePoint.rotation);
        // projectile.GetComponent<PlayerProjectile>().projectileSpawnPosition = projectileSpawnPosition;
        

        
        // Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        // rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
        // rb.freezeRotation = true;
    }
}