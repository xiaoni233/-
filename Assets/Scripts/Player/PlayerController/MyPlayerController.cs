using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    PlayerInputMgr input ;
    PlayerGroundDetector groundDetector;
    public float MoveSpeed => Mathf.Abs(rigidbody2D.velocity.x);
    public bool IsGrounded => groundDetector.IsGrounded;
    public bool IsFalling => rigidbody2D.velocity.y < 0f && !IsGrounded;
    public bool CanAirJump { get; set; } = true;

    public EnemyStateMachine enemySM;
       
    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        input = PlayerInputMgr.GetInstance();
            
    }
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerInputMgr.GetInstance().EnableGameplayInput();
    }
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody2D.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        rigidbody2D.velocity =new Vector3 (velocityX,rigidbody2D.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x,velocityY);
    }
    public void Move(float speed)
    {
        if(input.IsMove)
        {
            transform.localScale = new Vector3(input.AxesX, 1f, 1f);
        }
        SetVelocityX(speed * input.AxesX);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.name + "enter if");
            if(input.IsAttack)
            {
                enemySM.enemyController.getHit = true;
                Debug.Log("player hit" + enemySM.enemyController.getHit);
            }
        }
    }
}
