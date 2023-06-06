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

    AudioSource shootSound;

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
        GetComponent<AudioSource>().Play();
        // Instantiate a bullet at the fire point position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Set the bullet's velocity to move in the direction based on the cannon's rotation and scale
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.right * bulletSpeed * transform.localScale.x;

        // Flip the bullet sprite based on the cannon's scale
        SpriteRenderer bulletSprite = bullet.GetComponent<SpriteRenderer>();
        bulletSprite.flipX = transform.localScale.x < 0f;

        Destroy(bullet, bulletLife);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (transform.right * bulletSpeed * bulletLife * transform.localScale.x));
    }
}
