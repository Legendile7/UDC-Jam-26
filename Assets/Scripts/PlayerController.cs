using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        //if (isGrounded && playerVelocity.y < 0)
        //{
            //playerVelocity.y = -2f;
        //}

        float moveDirection = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * moveDirection;
        controller.Move(move * movementSpeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
        }

        playerVelocity.y -= gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
