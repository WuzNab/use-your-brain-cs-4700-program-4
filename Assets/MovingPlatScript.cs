using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatScript : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    int direction = -1;
    private void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.MoveTowards(platform.position, target,speed * Time.deltaTime);
        float distance = (target - (Vector2)platform.position).magnitude;
        if (distance < 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
            return endPoint.position;

    }
    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.collider.name != "BalloonBaby")
        {
            collision.gameObject.transform.SetParent(platform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.collider.name != "BalloonBaby")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
