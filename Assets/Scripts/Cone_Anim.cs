using UnityEngine;

public class Cone_Anim : MonoBehaviour
{
    public float maxFallingSpeed = 5f;

    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    public ConePlayer cone;
    public FootBallPlayer football;
    public BalloonPlayer balloon;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.linearVelocityY == 0 && rb.linearVelocityX == 0 && cone.enabled == false)
        {
            animator.Play("Player_Idle");
        }
        else
        {
            if (rb.linearVelocityY > 0 && cone.enabled == false)
            {
                animator.Play("Player_Jump");
            }
            else if (rb.linearVelocityY < 0 && cone.enabled == false)
            {
                animator.Play("Player_Fall");

            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = rb.linearVelocity;

        if (currentVelocity.y < 0)
        {
            currentVelocity.y = Mathf.Max(currentVelocity.y, -maxFallingSpeed);
        }

        rb.linearVelocity = currentVelocity;
    }

}
