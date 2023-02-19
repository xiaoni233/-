using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class DemoCollegeStudentController : MonoBehaviour
    {
        public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5
        public int anmo_blue = 100;
        public Text HealthNum;
        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        private float m_timer;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            HealthNum.text = anmo_blue.ToString();
            anmo_blue = 100;
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                KickBoard();
                Run();

            }
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isKickboard)
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }

        void Run() //定义跑步
        {
            if (!isKickboard)//键盘输入
            {
                Vector3 moveVelocity = Vector3.zero; //定义速度移动的向量坐标
                anim.SetBool("isRun", false);


                if (Input.GetAxisRaw("Horizontal") < 0) //对于键盘和游戏杆输入（水平）值小于0
                {
                    direction = -1;//方向=-1
                    moveVelocity = Vector3.left;  //速度移动（向左）

                    transform.localScale = new Vector3(direction, 1, 1);//转换猪脚的坐标为为（方向，1，1）
                    if (!anim.GetBool("isJump"))//如果输出为跳
                        anim.SetBool("isRun", true);//动作动画则为跑动画

                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                transform.position += moveVelocity * movePower * Time.deltaTime;

            }
            if (isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)//键盘输入跳跃键后，如果输入猪脚垂直坐标>0
            && !anim.GetBool("isJump"))//或者骨骼动画输出为跳跃
            {
                isJumping = true;//确认是否跳跃
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;//定义猪脚垂直坐标

            Vector2 jumpVelocity = new Vector2(0, jumpPower);//输出跳跃移动坐标
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);//人物跳跃施力

            isJumping = false;//结束跳跃
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
        void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Enemies")
            {
        if (!anim.GetBool("isKickBoard"))
                {
            anmo_blue = anmo_blue - 30;
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }
            }
        }
    }
        void Die()
        {
            if(anmo_blue <= 0){
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Collection")
            {
                Destroy(collision.gameObject);
                    anmo_blue += 60;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Enemies")
            {
                    if (anim.GetBool("isKickBoard"))
                {
                     WuHanChengEnemy.Hit();
                     m_timer += Time.time;
        if (m_timer >= 3)
        {
               Destroy(collision.gameObject);
        }
         m_timer = 0;
                }
            }
         }
        }
    }