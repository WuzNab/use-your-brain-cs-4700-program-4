using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject target; // e.g. door, platform, etc.

    private SpriteRenderer sr;
    public Color idleColor = Color.white;
    public Color pressedColor = Color.green;

    private int playersOnPlate = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = idleColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
        if (sr != null) sr.color = pressedColor;

        // Example: enable a platform or open a door
        if (target != null)
        {
            target.SetActive(true);
        }
    }

    void OnReleased()
    {
        Debug.Log("Plate released!");
        if (sr != null) sr.color = idleColor;

        // Example: disable the platform / close door
        if (target != null)
        {
            target.SetActive(false);
        }
    }
}
