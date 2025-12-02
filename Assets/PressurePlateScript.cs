using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject target; // e.g. door, platform, etc.
    private SpriteRenderer sr;
    public Sprite idleSprite;
    public Sprite spritePressed;
    private AudioSource audioSource;
    public AudioClip pressSound;
    private int playersOnPlate = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        if (sr != null)
        {
            idleSprite = sr.sprite;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponent<SpriteRenderer>().name != "balloonBaby")
        {
            playersOnPlate++;

            if (playersOnPlate == 1)
            {
                OnPressed();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersOnPlate--;

            if (playersOnPlate <= 0)
            {
                playersOnPlate = 0;
                OnReleased();
            }
        }
    }

    void OnPressed()
    {
        Debug.Log("Plate pressed!");

        if (sr != null)
        {
            sr.sprite = spritePressed;
        }

        if (target != null)
        {
            target.SetActive(false);
        }
        if (audioSource != null && pressSound != null)
        {
            audioSource.PlayOneShot(pressSound);
        }
    }

    void OnReleased()
    {
        Debug.Log("Plate released!");

        if (sr != null)
        {
            sr.sprite = idleSprite;
        }

        if (target != null)
        {
            target.SetActive(true);
        }

        if (audioSource != null && pressSound != null)
        {
            audioSource.PlayOneShot(pressSound);
        }
    }
}
