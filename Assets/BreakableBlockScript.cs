using UnityEngine;
using UnityEngine.Rendering;

public class BreakableBlockScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.GetComponent<FootBallPlayer>() != null ||
    collision.collider.GetComponentInParent<FootBallPlayer>() != null)
        {
            Destroy(gameObject);
        }
    }
}
