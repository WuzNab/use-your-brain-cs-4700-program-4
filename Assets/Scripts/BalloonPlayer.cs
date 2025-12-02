using UnityEngine;
using System.Collections;
public class BalloonPlayer : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float floatForce = 3f;
    public float maxForceU = 4f;
    public float maxForceD = -5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool facingRight = true;
    public float maxFallingSpeed = 6.5f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animator;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        Vector2 vel = rb.linearVelocity;
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        else if (moveInput > 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        SetAnimation(moveInput);

    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && !isGrounded)
        {
            rb.AddForce(Vector2.down * floatForce, ForceMode2D.Force);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }

        Vector2 vel = rb.linearVelocity;

        // Upward clamp
        if (vel.y > maxForceU)
            vel.y = maxForceU;

        // Optional downward clamp
        if (vel.y < maxForceD)
            vel.y = maxForceD;

        rb.linearVelocity = vel;
    }
    private void SetAnimation(float moveInput)
    {
        if (isGrounded || rb.linearVelocity.y < 0)
        {
            if (moveInput == 0)
            {
                animator.Play("idle+movement_baby");
            }
            else
            {
                animator.Play("idle+movement_baby");
            }
        }
        else
        {
            if (rb.linearVelocityY > 0)
            {
                animator.Play("idle+movement_baby");
            }
            else
            {
                animator.Play("idle+movement_baby");

            }
        }
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void ResetPlayerState()
    {
        rb.linearVelocity = Vector2.zero;
        animator.Play("idle+movement_baby");
    }

}