using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject followObject;
    public Vector2 followOffset;
    public Vector2 threshold;
    public float speed = 4f;
    private Rigidbody2D rb;

    public GameObject[] players; // size 3
    public CameraFollow cam;     // assign in Inspector
    private int activePlayer = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTo(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTo(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchTo(2);
        }
    }

    void SwitchTo(int index)
    {
        activePlayer = index;
        cam.SetFollowTarget(players[index], true);
    }
    void Start()
    {
        threshold = calculateThreshold();
        rb = followObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if (Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }
        float moveSpeed = rb.linearVelocity.magnitude > speed ? rb.linearVelocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
    public void SetFollowTarget(GameObject newTarget, bool snap = false)
    {
        followObject = newTarget;
        rb = followObject.GetComponent<Rigidbody2D>();
        if (snap)
            SnapToTarget();
    }

    public void SnapToTarget()
    {
        if (followObject == null) return;

        Vector3 pos = transform.position;
        pos.x = followObject.transform.position.x;
        pos.y = followObject.transform.position.y;
        transform.position = pos;
    }

}
