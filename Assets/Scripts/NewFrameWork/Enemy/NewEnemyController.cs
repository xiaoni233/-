using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyController : Entity
{
    //组件
    PlayerInputMgr input;
    Rigidbody2D rb;
    BoxCollider2D boxColl;
    CircleCollider2D cirColl;
    public PlayerInputMgr Input { get => input; private set => input = value; }
    public BoxCollider2D BoxColl { get => boxColl; set => boxColl = value; }
    public CircleCollider2D CirColl { get => cirColl; set => cirColl = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }


    //动画条件和人物状态
    public bool isMove=>InRange();//不在范围内会触发bug
    public bool isWall;
    public bool isIdle => AtPoint();
    public bool isHit;
    public bool isReact=>PlayerCheck();
    public bool isDead=>health<0;
    public bool isRecover;
    public bool isOutRange => OutOfRange();
    
    public bool isAttack;
    public bool isAttackReady=>PlayerCheck(attackDistance);

    public int health;
    public int moveDir;
    public float attackDistance = 0.5f;
    public float hitShakeDuration;
    public float hitShakeStrength;
    public int hitPauseDuration;//帧数
    //获得组件
    private void Awake()
    {
        isAttack = false;
        moveDir = 1;
        Rb = GetComponent<Rigidbody2D>();
        input = GetComponentInChildren<PlayerInputMgr>();
        BoxColl = GetComponent<BoxCollider2D>();
        CirColl = GetComponent<CircleCollider2D>();
        //自定义组件
        ComponentInitialize();
    }
    private void Start()
    {
        MyEventCenter.GetInstance().AddEventListener("NewEnemyHurt", SetIsHitTrue);
    }

    private void FixedUpdate()
    {
       
    }

    #region 刚体速度
    /// <summary>
    /// 刚体
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocity(Vector3 velocity)
    {
        Rb.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        Rb.velocity = new Vector3(velocityX, Rb.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        Rb.velocity = new Vector3(Rb.velocity.x, velocityY);
    }
    #endregion

    #region 给刚体力
    public void SetForce(Vector2 force)
    {
        Rb.AddForce(force);
    }
    public void SetForceX(float forceX)
    {
        Vector2 forceV = new Vector2(forceX, 0f);
        rb.AddForce(forceV);
    }
    public void SetForceY(float forceY)
    {
        Vector2 forceV = new Vector2(0f, forceY);
        rb.AddForce(forceV);
    }
    #endregion

    #region 动画事件函数
    public void Move()
    {
        EnemyMove move= GetComponentInChildren<EnemyMove>();
        move.MoveBySpeed();
    }
    public void SetHitFalse()
    {
        isHit = false;
    }
    public void SetHitTrue()
    {
        isHit = true;
       
    }
    public void SetIsRecoverTrue()
    {
        
        isRecover = true;
    }
    public void SetIsRecoverFalse()
    {
       
        isRecover = false;
    }
    public void Pause()
    {
        CameraController.Instance.Pause();
    }
    public void TimeRecover()
    {
        CameraController.Instance.TimeRecover();
    }
    public void HitPause()
    {
        CameraController.Instance.HitPause(hitPauseDuration);
    }
    public void HitCameraShake()
    {
        CameraController.Instance.CameraShake(hitShakeDuration, hitShakeStrength);
    }
    public void AttackPlayer()
    {
        MyEventCenter.GetInstance().EventTrigger("NewPlayerHurt");
    }

    #endregion

    #region 调用组件函数
    private bool OutOfRange()
    {
        Patrol patrol = GetComponentInChildren<Patrol>();
       return !patrol.PatrolCheckXIn();
    }
    private bool InRange()
    {
        Patrol patrol = GetComponentInChildren<Patrol>();
        return patrol.PatrolCheckXIn();
    }
    private bool AtPoint()
    {
        Patrol patrol = GetComponentInChildren<Patrol>();
        return patrol.PatrolAtLPoint() || patrol.PatrolAtRPoint();
    }
    private bool PlayerCheck()
    {
        PlayerCheck check = GetComponentInChildren<PlayerCheck>();
        return check.CheckPlayer();
    }
    private bool PlayerCheck(float distance)
    {
        PlayerCheck check = GetComponentInChildren<PlayerCheck>();
        return check.CheckPlayer(distance);
    }
    private void SetIsHitTrue()
    {
        Debug.Log("SetIsHitTrue()");
        isHit = true;
        health--;
    }
    private void SetIsHitFalse()
    {
        Debug.Log("SetIsHitFalse()");
        isHit = false;
    }
   
    
    #endregion


}
