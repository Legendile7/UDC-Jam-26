using UnityEngine;
using System.Collections;
using TMPro;

public class LaserBeam : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float damageInterval = 1f;
    private bool canDamage = true;
    [SerializeField] private int damage = 15;
    public float maxBeamDistance;
    public bool shootsRight = true;
    private Vector2 maxBeam;

    private void Start()
    {
        maxBeam = new Vector2(maxBeamDistance, transform.position.y);
    }

    private void Update()
    {
        FireLaserBeam();
    }

    private void FireLaserBeam()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit2D hit;
        if (shootsRight)
        {
            hit = Physics2D.Raycast(transform.position, -transform.right);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, transform.right);
        }

        if (hit && Lights.lightsOn)
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Player") && canDamage)
            {
                PlayerHealth healthManager = hit.collider.GetComponent<PlayerHealth>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(damage);
                    StartCoroutine(ResetDamageInterval());
                }
            }
        }
        else if (!Lights.lightsOn)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
        else
        {
            lineRenderer.SetPosition(1, maxBeam);
        }
    }

    private IEnumerator ResetDamageInterval()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageInterval);
        canDamage = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (shootsRight)
        {
            Gizmos.DrawLine(transform.position, new Vector2(maxBeamDistance, transform.position.y));
        }
        else
        {
            Gizmos.DrawLine(transform.position, new Vector2(-maxBeamDistance, transform.position.y));
        }
    }
}
