using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public Vector2 movement;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        movement = Vector2.zero; 
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
            Debug.Log("Is Grounded: " + isGrounded);
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
