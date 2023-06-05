using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float beamLength = 10f;
    public float damageInterval = 1f;
    private bool canDamage = true;

    private void Start()
    {
        FireLaserBeam();
    }

    private void Update()
    {
        FireLaserBeam();
    }

    private void FireLaserBeam()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, beamLength);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Player") && canDamage)
            {
                PlayerHealth healthManager = hit.collider.GetComponent<PlayerHealth>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(15); // Adjust the damage amount as needed
                    StartCoroutine(ResetDamageInterval());
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.right * beamLength);
        }
    }

    private IEnumerator ResetDamageInterval()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageInterval);
        canDamage = true;
    }
}
