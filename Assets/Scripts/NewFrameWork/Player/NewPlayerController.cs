using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewPlayerController : MonoBehaviour
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
    //自定义组件
    public MyConponent[] myComponents;
    private Dictionary<System.Type, MyConponent> componentTable;

    public ScreenFlash sf;
    private PlayerMove move;
    private ChangeDirection direction;
    private GroundCheck groundDetector;
    private PlayerJump jump;
    //动画条件和人物状态
    public bool isMove=>input.IsMove;
    public bool isJump => input.IsJump&&groundDetector.CheckGround();
    public bool isFalling => groundDetector.CheckGround() == false;
    public bool isWall => WallCheck();
    public bool isFall => groundDetector.CheckGround(fallDistance)&&rb.velocity.y<0;
    public bool isLand => groundDetector.CheckGround(landDistance) && rb.velocity.y < 0;
    public bool isIdle => !isAttack;
    public bool isLightAttack => input.IsLightAttackButtonDowm();
    public bool isAttack;
    public bool isAttackReady;
    public bool isHurt=false;
    //打击出问题的原因是被默认状态抢animator
    
    //其他参数
    public float moveDir = 0;
    public float fallDistance = 1.45f;
    public float landDistance = 1.15f;
    public float fallGravityScale;

    public float hitTimePic;//帧数
    public float hitStrength;
    public int heatlh;
    //public float airMoveSpeed;
    //获得组件
    private void Awake()
    {
      
        Rb = GetComponent<Rigidbody2D>();
        input = GetComponentInChildren<PlayerInputMgr>();
        BoxColl = GetComponent<BoxCollider2D>();
        CirColl = GetComponent<CircleCollider2D>();
        //自定义组件
        ComponentInitialize();

        move = GetComponentInChildren<PlayerMove>();
        direction = GetComponentInChildren<ChangeDirection>();
        groundDetector = GetComponentInChildren<GroundCheck>();
        jump= GetComponentInChildren<PlayerJump>();

        //状态初始化
        isAttack = false;
        HealthInit();
    }
    private void Start()
    {
        
        MyEventCenter.GetInstance().AddEventListener("NewPlayerHurt", Hurt);
    }
    private void FixedUpdate()
    {
        Loss();
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

    #region 事件函数
    void Loss()
    {
        if (heatlh <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    void Move()
    {
        //if (groundDetector.CheckGround())
        //{
        //    move.Move();
        //}      
        move.Move();
    }
   
    void PauseMove()
    {
        move.PauseMove();
    }
    void ChangeDir()
    {
        direction.ChangeDirX(-(int)moveDir);
    }
    void Jump()
    {
         jump.Jump();
        //jump.JumpBySetVelocityY();
    }
    void FallGiveSpeed()
    {
        if(rb.velocity.y < 0)
        {
            //jump.FallVelocityY();
            jump.FallByGravityScale(fallGravityScale);
        } 
       
    }
    void Land()
    {
            jump.FallByGravityScale(1f);       
    }
    //test
    bool WallCheck()
    {
        if (componentTable.ContainsKey(typeof(WallCheck)) ==true)
        { //具体获得和使用        
            WallCheck wallCheck = (WallCheck)componentTable[typeof(WallCheck)];
            return wallCheck.CheckWall();
        }
        else return false;
    }
    public void SetIsAttackReadyTrue()
    {
        isAttackReady = true;
    }
    public void isAttackFalse()
    {
        isAttack = false;
    }
    public void SetComboOne()
    {
        if (componentTable.ContainsKey(typeof(NewPlayerAttackAnim)) == true)
        { //具体获得和使用        
            NewPlayerAttackAnim attackAnim = (NewPlayerAttackAnim)componentTable[typeof(NewPlayerAttackAnim)];
            attackAnim.SetComboCountOne();
        }
    }
    public void ComboPlus()
    {
        if (componentTable.ContainsKey(typeof(NewPlayerAttackAnim)) == true)
        {
            NewPlayerAttackAnim attackAnim = (NewPlayerAttackAnim)componentTable[typeof(NewPlayerAttackAnim)];
            attackAnim.ComboCountPlus();
        }
    }
    public void EnemyHurtTrigger()
    {    
        if (componentTable.ContainsKey(typeof(HitBox))==true)
        {         
            HitBox hitBox = (HitBox)componentTable[typeof(HitBox)];           
            if(hitBox.IsObjHurt("Enemy"))
            {
                MyEventCenter.GetInstance().EventTrigger("NewEnemyHurt");
            }          
        }     
    }
    #endregion


    private void  ComponentInitialize()
    {
        componentTable = new Dictionary<System.Type, MyConponent>(myComponents.Length);
        foreach (MyConponent cp in myComponents)
        {
            componentTable.Add(cp.GetType(), cp);
        }
    }

    #region 其他函数
    private void Hurt()
    {
        heatlh--;
        MyHealthBar.HealthCurrent=heatlh;
        sf.FlashScreen();
        HitShake();
    }
    private void HealthInit()
    {
        MyHealthBar.HealthCurrent = heatlh;
    }
    private void HitShake()
    {
        CameraController.Instance.CameraShake(hitTimePic, hitStrength);
    }
    #endregion
  
}


