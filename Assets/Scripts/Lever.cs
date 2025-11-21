using UnityEngine;

public class Lever : MonoBehaviour
{
    public Door door; // assign this in Inspector btw
    private bool playerInRange = false;

    void Update()
    {

        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            door.OpenDoor();
        }

    }

    // These are to check if the player is in range of the lever, to interact
    // the lever and they are not able to while being accross the map/level.
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player")) // only affects with tags of Player
        {
            playerInRange = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = false;        
        }
        
    }
}
