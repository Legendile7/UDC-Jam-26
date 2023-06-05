using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;

    private Rigidbody2D rb;
    private Vector2 platformVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PlayerHealth.alive)
        {
            // Horizontal movement
            float moveX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

            // Jumping
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with a moving platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Check collision normal to determine if the player is on top of the platform
            ContactPoint2D[] contacts = collision.contacts;
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i].normal.y > 0.7f) // Check if collision is from below
                {
                    // Attach the player to the platform by setting its parent
                    transform.parent = collision.transform;
                    platformVelocity = collision.rigidbody.velocity;
                    break;
                }
            }
        }
        // Reset jumping flag when touching the ground
        /*
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        */
        ContactPoint2D[] contacts2 = collision.contacts;
        for (int i = 0; i < contacts2.Length; i++)
        {
            if (contacts2[i].normal.y > 0.7f) // Check if collision is from below
            {
                isJumping = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player left a moving platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Detach the player from the platform by resetting its parent
            transform.parent = null;
            platformVelocity = Vector2.zero;
        }
    }
}
