using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 25;

    private PlayerHealth healthMan;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (healthMan.currentHealth != 100)
        {
            healthMan.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
