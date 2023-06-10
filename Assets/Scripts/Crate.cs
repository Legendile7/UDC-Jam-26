using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 platformVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the crate collided with a moving platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Check collision normal to determine if the crate is on top of the platform
            ContactPoint2D[] contacts = collision.contacts;
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i].normal.y > 0.7f) // Check if collision is from below
                {
                    // Attach the crate to the platform by setting its parent
                    transform.parent = collision.transform;
                    platformVelocity = collision.rigidbody.velocity;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the crate left a moving platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Detach the crate from the platform by resetting its parent
            transform.parent = null;
            platformVelocity = Vector2.zero;
        }
    }
}
