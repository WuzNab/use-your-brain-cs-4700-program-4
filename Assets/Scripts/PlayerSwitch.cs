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

    public Cone_Anim coneAnim;
    public Football_Anim FootballAnim;
    public BalloonAnim BalloonAnim;

    private void Start()
    {
        coneSR.sortingOrder = 2;
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
            footballSR.sortingOrder = 1;
            coneSR.sortingOrder = 2;
            footballRB.linearVelocity = Vector2.zero;
            football.enabled = false;
            cone.enabled = true;
            footballActive = false;
            coneActive = true;
        }
        else if (balloonActive)
        {
            balloonSR.sortingOrder = 1;
            coneSR.sortingOrder = 2;
            balloonRB.linearVelocity = Vector2.zero;
            balloon.enabled = false;
            cone.enabled = true;
            balloonActive = false;
            coneActive =true;
        }
    }

    public void footballSwitch()
    {
        if (coneActive)
        {
            coneSR.sortingOrder = 1;
            footballSR.sortingOrder = 2;
            coneRB.linearVelocity = Vector2.zero;
            cone.enabled = false;
            football.enabled = true;
            coneActive = false;
            footballActive = true;
        }
        else if (balloonActive)
        {
            balloonSR.sortingOrder = 1;
            footballSR.sortingOrder = 2;
            balloonRB.linearVelocity = Vector2.zero;
            balloon.enabled = false;
            football.enabled = true;
            balloonActive = false;
            footballActive = true;
        }
    }

    public void balloonSwitch()
    {
        if (coneActive)
        {
            coneSR.sortingOrder = 1;
            balloonSR.sortingOrder = 2;
            coneRB.linearVelocity = Vector2.zero;
            cone.enabled = false;
            balloon.enabled = true;
            coneActive = false;
            balloonActive = true;
        }
        else if (footballActive)
        {
            footballSR.sortingOrder = 1;
            balloonSR.sortingOrder = 2;
            footballRB.linearVelocity = Vector2.zero;
            football.enabled = false;
            balloon.enabled = true;
            footballActive = false;
            balloonActive = true;
        }
    }
}
