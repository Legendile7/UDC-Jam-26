using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportTarget;

    private AudioSource teleportSound;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        AudioSource[] audioSources = player.GetComponents<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.clip != null && audioSource.clip.name == "Teleport")
            {
                teleportSound = audioSource;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Lights.lightsOn)
            {
                teleportSound.Play();
                TeleportPlayer(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Lights.lightsOn)
            {
                teleportSound.Play();
                TeleportPlayer(collision.gameObject);
            }
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        player.transform.position = teleportTarget.transform.position;
    }
}
