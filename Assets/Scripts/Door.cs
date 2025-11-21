using UnityEngine;

public class Door : MonoBehaviour
{
    // tracks if door is open
    private bool DoorisOpen = false;

    public void OpenDoor()
    {
        // when door open
        if (DoorisOpen) return; 
        DoorisOpen = true;

        // allows player to pass through
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // fades the door to show it's open | convenient to skip animations
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            sr.color = new Color(c.r, c.g, c.b, 0.3f);
        }
    }
}
