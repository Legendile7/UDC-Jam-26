using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public bool needsElectricity = true;
    public bool animated;
    public bool repeatDamage = true;
    private bool isEnabled;
    private bool colliding;

    public float damageInterval = 1f;
    private bool canDamage = true;
    [SerializeField] private int damage = 15;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (!needsElectricity)
        {
            isEnabled = true;
            Animate(true);
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            isEnabled = false;
            Animate(false);
            GetComponent<BoxCollider2D>().enabled = false;
            colliding = false;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isEnabled && colliding && canDamage && repeatDamage)
        {
            PlayerHealth healthManager = player.GetComponent<PlayerHealth>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damage);
                StartCoroutine(ResetDamageInterval());
            }
        }
    }
    void Animate(bool condition)
    {
        if (animated)
        {
            Animator a = GetComponent<Animator>();
            if (condition)
            {
                a.SetTrigger("On");
            }
            else
            {
                a.SetTrigger("Off");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Lights.lightsOn)
        {
            Animate(true);
            GetComponent<BoxCollider2D>().enabled = true;
            isEnabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Lights.lightsOn)
        {
            Animate(false);
            GetComponent<BoxCollider2D>().enabled = false;
            colliding = false;
            isEnabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colliding = true;
            if (!repeatDamage)
            {
                PlayerHealth healthManager = player.GetComponent<PlayerHealth>();
                healthManager.TakeDamage(damage);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colliding = false;
        }
    }

    private IEnumerator ResetDamageInterval()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageInterval);
        canDamage = true;
    }
}
