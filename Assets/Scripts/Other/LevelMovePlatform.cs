using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovePlatform : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        ChangeDirMove();
    }
    private void ChangeDirMove()
    {
        if(transform.localPosition.x<=left.localPosition.x)
        {
            speed = Mathf.Abs(speed);
        }
        if( transform.localPosition.x >= right.localPosition.x)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void Move()
    {
        rb.velocity = new Vector2(speed, 0f);
    }
}
