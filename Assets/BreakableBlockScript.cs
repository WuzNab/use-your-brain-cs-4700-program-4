using UnityEngine;

public class BreakableBlockScript : MonoBehaviour
{
    public AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only FootballPlayer can break it
        if (collision.collider.GetComponent<FootBallPlayer>() != null ||
            collision.collider.GetComponentInParent<FootBallPlayer>() != null)
        {
            BreakNow();
        }
    }

    void BreakNow()
    {
        // Play sound at the block’s position (sound survives after object is gone)
        if (breakSound != null)
            AudioSource.PlayClipAtPoint(breakSound, transform.position);

        Destroy(gameObject); // destroy instantly
    }
}
