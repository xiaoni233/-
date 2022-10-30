using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public Rigidbody2D Rigidbody2D { get => rigidbody2D;  set => rigidbody2D = value; }
    PlayerInputMgr input ;
    PlayerGroundDetector groundDetector;
    PlayerVarious various;
    //用于获得碰撞信息
     private  HitBox hitBox;
    private BoxCollider2D boxCollider2D;
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    private CircleCollider2D circleCollider;
    public CircleCollider2D CircleCollider { get => circleCollider; set => circleCollider = value; }

    //"人物状态"
    public float MoveSpeed => Mathf.Abs(Rigidbody2D.velocity.x);
    public bool IsGrounded => groundDetector.IsGrounded;
    public bool IsFalling => Rigidbody2D.velocity.y < 0f && !IsGrounded;
    public bool CanAirJump { get; set; } = true;
    [HideInInspector] public float moveDir=0; //移动方向

    [Header("Dash参数")]
    public float dashTime;//dash时长
    [HideInInspector] public float dashTimeLeft;//冲锋剩余时间
    [HideInInspector] public float lastDash=-10f;//上次dash时间点
    public float dashCoolDown;
    public float dashSpeed;

    [Header("战斗参数")]
    public int healthValue;
    private bool getHit;
    public bool GetHit { get => getHit; private set => getHit = value; }    

    public float hitStiffTime;

    
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        CircleCollider = GetComponent<CircleCollider2D>();
    }
   
    void Start()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();             
        input = PlayerInputMgr.GetInstance();
        hitBox = GetComponentInChildren<HitBox>();
        PlayerInputMgr.GetInstance().EnableGameplayInput();
        MyEventCenter.GetInstance().AddEventListener("PlayerHurt", SetgetHitTrue);
        various = PlayerVarious.GetInstance();
        various.playerHitbox = hitBox;
    }


    #region 刚体速度
    public void SetVelocity(Vector3 velocity)
    {
        Rigidbody2D.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        Rigidbody2D.velocity =new Vector3 (velocityX,Rigidbody2D.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        Rigidbody2D.velocity = new Vector3(Rigidbody2D.velocity.x,velocityY);
    }
    #endregion

    public void Move(float speed)
    {
        if (input.AxesX != 0)
        {
            moveDir = Mathf.Abs(input.AxesX) * (1 / input.AxesX);
        }
        if (input.IsMove)
        {
            transform.localScale = new Vector3(moveDir, 1f, 1f);
        }
        SetVelocityX(speed * moveDir);
    }

    private void SetgetHitTrue()
    {
        SetgetHit(true);
    }
    public void SetgetHit(bool value)
    {
        GetHit = value;
    }

   
}
