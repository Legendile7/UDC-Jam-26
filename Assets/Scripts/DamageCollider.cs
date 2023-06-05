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
        if (needsElectricity && Lights.lightsOn || !needsElectricity)
        {
            isEnabled = true;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (needsElectricity && Lights.lightsOn)
        {
            if (!isEnabled && animated)
            {
                Animate(true);
            }
            isEnabled = true;
        }
        else if (needsElectricity && !Lights.lightsOn)
        {
            if (isEnabled && animated)
            {
                Animate(false);
            }
            isEnabled = false;
        }
        if (isEnabled)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            colliding = false;
        }
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
            StartCoroutine(ResetDamageInterval());
        }
    }

    private IEnumerator ResetDamageInterval()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageInterval);
        canDamage = true;
    }
}