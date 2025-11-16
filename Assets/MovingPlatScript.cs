using UnityEngine;

public class MovingPlatScript : MonoBehaviour
{
    private Rigidbody2D rb;
     private float dirX;
    private float moveSpeed = 3f;
    private Vector3 localScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // Update this so that you change the collision to the name of the wall script that we collide to 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Grid>() != null ||
        collision.GetComponentInParent<Grid>() != null)
        {
            dirX *= -1f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);
    }
}
