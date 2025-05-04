using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 10f;
    public bool IsJumping;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb2d.linearVelocity = new Vector2(moveInput.x * Speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsJumping = true;
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Water"))
        {
            IsJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Water"))
        {
            IsJumping = true;
        }
    }
}