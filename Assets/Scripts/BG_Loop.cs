using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Loop : MonoBehaviour
{
    private BoxCollider2D boxColl;
    private Rigidbody2D rb;

    private float length;

    private float speed = -3f;

    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        length = boxColl.size.y;
        rb.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if(transform.position.y < -length)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 vector = new Vector2(0, length * 2);
        transform.position = (Vector2)transform.position + vector;
    }
    
}
