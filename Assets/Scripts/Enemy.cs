using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    void Update()
    {
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

}
