using Unity.Collections;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public SpriteRenderer coneSR;
    public SpriteRenderer footballSR;
    public SpriteRenderer balloonSR;

    public ConePlayer cone;
    public FootBallPlayer football;
    public BalloonPlayer balloon;

    public bool coneActive = true;
    public bool footballActive = false;
    public bool balloonActive = false;
    public Rigidbody2D coneRB;
    public Rigidbody2D footballRB;
    public Rigidbody2D balloonRB;

    private void Start()
    {
        coneSR.sortingOrder = 2;
        coneRB.constraints = RigidbodyConstraints2D.FreezeRotation; // allow movement

        // Freeze the other two zombies
        footballRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        balloonRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        // Make sure only Cone is active at start
        football.enabled = false;
        balloon.enabled = false;

        footballActive = false;
        balloonActive = false;
        coneActive = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            coneSwitch();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            footballSwitch();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            balloonSwitch();
        }
    }

    public void coneSwitch()
    {
            if (footballActive)
            {
                // footballSR.sortingOrder = 1;
                // coneSR.sortingOrder = 2;
                // footballRB.linearVelocity = Vector2.zero;
                // football.enabled = false;
                // cone.enabled = true;
                // footballActive = false;
                // coneActive = true;
                // football.ResetPlayerState();
                footballSR.sortingOrder = 1;
                coneSR.sortingOrder = 2;

                footballRB.linearVelocity = Vector2.zero;
                football.enabled = false;
                footballActive = false;
                footballRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                cone.enabled = true;
                coneActive = true;
                coneRB.constraints = RigidbodyConstraints2D.FreezeRotation;

                // Freeze the third character
                balloonRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            else if (balloonActive)
            {
                // balloonSR.sortingOrder = 1;
                // coneSR.sortingOrder = 2;
                // balloonRB.linearVelocity = Vector2.zero;
                // balloon.enabled = false;
                // cone.enabled = true;
                // balloonActive = false;
                // coneActive = true;
                // balloon.ResetPlayerState();
                balloonSR.sortingOrder = 1;
                coneSR.sortingOrder = 2;

                balloonRB.linearVelocity = Vector2.zero;
                balloon.enabled = false;
                balloonActive = false;
                balloonRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                cone.enabled = true;
                coneActive = true;
                coneRB.constraints = RigidbodyConstraints2D.FreezeRotation;

                // Freeze the third character
                footballRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
    }

    public void footballSwitch()
    {

            if (coneActive)
            {
                // coneSR.sortingOrder = 1;
                // footballSR.sortingOrder = 2;
                // coneRB.linearVelocity = Vector2.zero;
                // cone.enabled = false;
                // football.enabled = true;
                // coneActive = false;
                // footballActive = true;
                // cone.ResetPlayerState();
                coneSR.sortingOrder = 1;
                footballSR.sortingOrder = 2;

                // Freeze cone
                coneRB.linearVelocity = Vector2.zero;
                coneRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                // Enable football
                cone.enabled = false;
                football.enabled = true;
                coneActive = false;
                footballActive = true;
                cone.ResetPlayerState();

                // Freeze balloon
                balloonRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                // UNFREEZE football
                footballRB.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            else if (balloonActive)
            {
                // balloonSR.sortingOrder = 1;
                // footballSR.sortingOrder = 2;
                // balloonRB.linearVelocity = Vector2.zero;
                // balloon.enabled = false;
                // football.enabled = true;
                // balloonActive = false;
                // footballActive = true;
                // balloon.ResetPlayerState();
                 balloonSR.sortingOrder = 1;
                footballSR.sortingOrder = 2;

                // Freeze balloon
                balloonRB.linearVelocity = Vector2.zero;
                balloonRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                // Enable football
                balloon.enabled = false;
                football.enabled = true;
                balloonActive = false;
                footballActive = true;
                balloon.ResetPlayerState();

                // Freeze cone
                coneRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                // UNFREEZE football
                footballRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        
    }

    public void balloonSwitch()
    {
        if (coneActive)
        {
            // coneSR.sortingOrder = 1;
            // balloonSR.sortingOrder = 2;
            // coneRB.linearVelocity = Vector2.zero;
            // cone.enabled = false;
            // balloon.enabled = true;
            // coneActive = false;
            // balloonActive = true;
            // cone.ResetPlayerState();
            coneSR.sortingOrder = 1;
            balloonSR.sortingOrder = 2;

            // Freeze cone
            coneRB.linearVelocity = Vector2.zero;
            coneRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            // Enable balloon
            cone.enabled = false;
            balloon.enabled = true;
            coneActive = false;
            balloonActive = true;
            cone.ResetPlayerState();

            // Freeze football
            footballRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            // UNFREEZE balloon
            balloonRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (footballActive)
        {
            // footballSR.sortingOrder = 1;
            // balloonSR.sortingOrder = 2;
            // footballRB.linearVelocity = Vector2.zero;
            // football.enabled = false;
            // balloon.enabled = true;
            // footballActive = false;
            // balloonActive = true;
            // football.ResetPlayerState();
            footballSR.sortingOrder = 1;
            balloonSR.sortingOrder = 2;

            // Freeze football
            footballRB.linearVelocity = Vector2.zero;
            footballRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            // Enable balloon
            football.enabled = false;
            balloon.enabled = true;
            footballActive = false;
            balloonActive = true;
            football.ResetPlayerState();

            // Freeze cone
            coneRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            // UNFREEZE balloon
            balloonRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
