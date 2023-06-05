using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
