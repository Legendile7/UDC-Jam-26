using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float maxDist = 5f;
    private bool canMove = false;
    float ogStart;
    private void Start()
    {
        ogStart = transform.position.y;
    }
    private void Update()
    {
        if (Lights.lightsOn)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
        if (canMove)
        {
            if (transform.position.y <= ogStart - maxDist || transform.position.y >= ogStart + maxDist)
            {
                speed = -speed;
            }
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y - maxDist - (GetComponent<BoxCollider2D>().size.y / 2) * transform.localScale.y), new Vector2(transform.position.x, transform.position.y + maxDist + (GetComponent<BoxCollider2D>().size.y / 2) * transform.localScale.y));
    }
}
