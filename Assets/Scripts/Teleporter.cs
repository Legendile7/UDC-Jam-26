using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Lights.lightsOn)
            {
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
                TeleportPlayer(collision.gameObject);
            }
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        player.transform.position = teleportTarget.transform.position;
    }
}
