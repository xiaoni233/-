using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyies : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    public LayerMask ground;
    public Transform leftpoint, rightpoint;
    public float speed, jumpforce;
    private float leftx, rightx;
    private bool Faceleft = true;

void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    
    {
        // if (Faceleft)
        // {
        //     if (coll.IsTouchingLayers(ground))
        //     {
        //         rb.velocity = new Vector2(-speed, jumpforce);
        //     }
        //     if (transform.position.x <= leftx)
        //     {
        //         transform.localScale = new Vector3(-1, 1, 1);
        //         rb.velocity = new Vector2(speed, jumpforce);
        //         Faceleft = false;
        //     }
        // }
        // else
        // {
        //     if (coll.IsTouchingLayers(ground))
        //     {
        //         rb.velocity = new Vector2(speed, jumpforce);
        //     }
        //     if (transform.position.x >= rightx)
        //     {
        //         transform.localScale = new Vector3(1, 1, 1);
        //         rb.velocity = new Vector2(-speed, jumpforce);
        //         Faceleft = true;
        //     }
        // }
    }
}