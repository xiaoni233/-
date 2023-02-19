using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    private CircleCollider2D circleCollider;
    public CircleCollider2D CircleCollider { get => circleCollider; set => circleCollider = value; }

    [HideInInspector] public HitBox hitBox;

    [Header("һ�����")]
    public float MoveSpeed;
    public float chaseSpeed;
    public float idleTime;

    [Header("�����")]
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;//�ǵ���һ��е��˵�ͼ������

    [Header("ս������")]
    public Transform attackPoint;
    public float attackArea;
    private bool getHit;
    public int health;
    public bool GetHit { get => getHit; private set => getHit = value; }
    public float getHitSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        CircleCollider = GetComponent<CircleCollider2D>();
        hitBox = GetComponentInChildren<HitBox>();
    }
    private void Start()
    {
        MyEventCenter.GetInstance().AddEventListener("EnemyHurt", SetgetHitTrue);
    }

    #region �����ٶ�
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody2D.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        rigidbody2D.velocity = new Vector3(velocityX, rigidbody2D.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, velocityY);
    }
    #endregion

    public void FlipTo(Transform target)
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void SetgetHitTrue()
    {
        Debug.Log("SetgetHitTrue");
        SetgetHit(true);
    }
    public void SetgetHit(bool value)
    {
        GetHit = value;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackArea);
    }
   
}
