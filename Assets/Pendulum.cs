using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;
    private bool movingClockwise;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    void Update()
    {
        Move(); 
    }

    public void ChangeMoveDirection()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }   

    public void Move()
    {
        ChangeMoveDirection();

        if (movingClockwise)
        {
            rb.angularVelocity = moveSpeed;
        }
        if (!movingClockwise)
        {
            rb.angularVelocity = -moveSpeed;
        }
    }
}
