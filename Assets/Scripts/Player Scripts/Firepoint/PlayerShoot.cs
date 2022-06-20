using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float projectileForce = 20f;

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position + firePoint.right * 1.2f, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
    }
}