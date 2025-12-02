using UnityEngine;
using UnityEngine.Rendering;

public class BreakableBlockScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AudioSource audioSource;
    public AudioClip breakSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Get or add AudioSource
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<FootBallPlayer>() != null ||
            collision.collider.GetComponentInParent<FootBallPlayer>() != null)
        {
            PlayBreakSoundAndDestroy();
        }
    }

    void PlayBreakSoundAndDestroy()
    {
        if (breakSound != null)
        {
            audioSource.PlayOneShot(breakSound);
        }

        // Destroy block after sound finishes
        Destroy(gameObject, breakSound.length);
    }
}
