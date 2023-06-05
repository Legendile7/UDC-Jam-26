using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float bulletSpeed = 10f;
    public float bulletLife = 7f;

    private float fireTimer = 0f;

    private void Update()
    {
        // Update the timer
        fireTimer += Time.deltaTime;

        // Check if it's time to fire
        if (fireTimer >= fireRate && Lights.lightsOn)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    private void Fire()
    {
        // Instantiate a bullet at the fire point position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Set the bullet's velocity to move in a straight horizontal line
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2(bulletSpeed, 0f);

        Destroy(bullet, bulletLife);
    }
}
