using UnityEngine;
using System.Collections;

public class HP_System_FootBaller : MonoBehaviour
{
    public int health = 3;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool facingRight = true;
    public float maxFallingSpeed = 5f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animator;

    private SpriteRenderer spriteRenderer;
    public float invincibilityDuration = 1.5f;
    private bool isInvincible = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Hit_Points.Instance.SetFootballHP(health);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Damage") && isInvincible == false)
        {
            Hit_Points.Instance.DamageFootball(1);
            StartCoroutine(BecomeTemporarilyInvincible());

            if (Hit_Points.Instance.Football_Zombie_Hit_Points <= 0)
            {
               
                Die();
            }
        }
        else if (collision.gameObject.CompareTag("Death"))
        {
            Hit_Points.Instance.SetFootballHP(0);
            Die();
        }
        else if (collision.gameObject.CompareTag("Super"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15);
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;

        // Visual feedback (e.g., flashing the sprite)
        float flashInterval = 0.1f;
        int numFlashes = (int)(invincibilityDuration / (flashInterval * 2));
        for (int i = 0; i < numFlashes; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashInterval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashInterval);
        }

        isInvincible = false;
    }
    private void Die()
    {
        if (Hit_Points.IsGameOver) { Time.timeScale = 0f; }
    }
    

}
