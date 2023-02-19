using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [Header("一般参数")]
    public float MoveSpeed;
    public float chaseSpeed;
    public int health;
    public bool getHit;
    public float idleTime;
    [Header("点参数")]
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;//记得玩家还有敌人的图层设置
    [Header("攻击参数")]
    public Transform attackPoint;
    public float attackArea;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

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

    public void FlipTo(Transform target)
    {
        float scaleXAbs =Mathf.Abs(transform.localScale.x);
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(scaleXAbs, transform.localScale.y, transform.localScale.z);
            }
            else if (transform.position.x < target.position.x)
            { 
                transform.localScale = new Vector3(-scaleXAbs, transform.localScale.y,transform.localScale.z );
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackArea);
    }
}
