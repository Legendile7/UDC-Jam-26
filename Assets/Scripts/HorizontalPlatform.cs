using UnityEditor;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float maxDist = 5f;
    private bool canMove = false;
    float ogStart;

    public bool generatorOn;
    private void Start()
    {
        ogStart = transform.position.x;
    }
    private void Update()
    {
        if (Lights.lightsOn)
        {
            canMove = true;
        }
        if (Lights.lightsOn & generatorOn)
        {
            canMove = true;
        }
        if (!Lights.lightsOn & generatorOn)
        {
            canMove = true;
        }
        if (!Lights.lightsOn & !generatorOn)
        {
            canMove = false;
        }
        if (canMove)
        {
            if (transform.position.x <= ogStart - maxDist || transform.position.x >= ogStart + maxDist)
            {
                speed = -speed;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector2(transform.position.x - maxDist - (GetComponent<BoxCollider2D>().size.x/2)*transform.localScale.x, transform.position.y), new Vector2(transform.position.x + maxDist + (GetComponent<BoxCollider2D>().size.x / 2) * transform.localScale.x, transform.position.y));
    }
}
