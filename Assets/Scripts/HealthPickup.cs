using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 25;

    private AudioSource pickupSound;
    private GameObject player;

    private PlayerHealth healthMan;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player");

        AudioSource[] audioSources = player.GetComponents<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.clip != null && audioSource.clip.name == "Pickup")
            {
                pickupSound = audioSource;
                break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (healthMan.currentHealth != 100)
        {
            healthMan.Heal(healAmount);
            pickupSound.Play();
            Destroy(gameObject);
        }
    }
}
