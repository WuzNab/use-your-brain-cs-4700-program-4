using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class HeadSuper : MonoBehaviour
{
    GameObject Enemy;

    private void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x, 15f);
        GetComponent<Collider2D>().enabled = false;
        Enemy.transform.Find("Gurburt").GetComponent<SpriteRenderer>().flipY = true;
        Enemy.transform.Find("Gurburt").GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        Enemy.transform.Find("Gurburt").transform.position = Enemy.transform.Find("Gurburt").transform.position + movement * Time.deltaTime;

    }
}