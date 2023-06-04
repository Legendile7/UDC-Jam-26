using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 2f;
    public GameObject background;
    private bool canMove = false;
    private Vector3 originalPosition;
    private Color originalBackgroundColor;

    private void Start()
    {
        originalPosition = transform.position;
        originalBackgroundColor = background.GetComponent<Renderer>().material.color;
    }

    private void Update()
    {
        if (background.GetComponent<Renderer>().material.color == Color.white)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }

        if (canMove)
        {
            float horizontalMovement = Mathf.Sin(Time.time) * speed;
            transform.Translate(Vector3.right * horizontalMovement * Time.deltaTime);
        }
        else
        {
            
        }
    }
}
