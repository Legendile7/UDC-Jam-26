using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite onSprite;
    public Sprite offSprite;

    public GameObject teleportTarget;

    private AudioSource teleportSound;
    private GameObject player;
    public bool generatorOn;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

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

    void Update()
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (Lights.lightsOn)
        {
            spriteRenderer.sprite = onSprite;
        }
        if (!Lights.lightsOn && !generatorOn)
        {
            spriteRenderer.sprite = offSprite;
        }
        if (!Lights.lightsOn && generatorOn)
        {
            spriteRenderer.sprite = onSprite;
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
            if (!Lights.lightsOn && generatorOn)
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
            if (!Lights.lightsOn && generatorOn)
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
