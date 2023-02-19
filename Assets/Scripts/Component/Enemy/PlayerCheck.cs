using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MyConponent
{
    public float playerCheckDistance;
    public LayerMask playerMask;
    public Vector2 direction;
    public NewEnemyController newEnemy;
    //public Transform father;

  
    private void Update()
    {
        
        direction = new Vector2(newEnemy.transform.localScale.x, 0f);
        
    }
    /// <summary>
    /// 返回有头朝向是否有玩家
    /// </summary>
    public bool CheckPlayer()
    {
        return Physics2D.Raycast(transform.position, direction, playerCheckDistance, playerMask);
    }
    /// <summary>
    /// 返回有头朝向是否有玩家
    /// </summary>
    public bool CheckPlayer(float distance)
    {
        return Physics2D.Raycast(transform.position, direction, distance, playerMask);
    }

    /// <summary>
    /// 编辑器 画出射线
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * playerCheckDistance));
    }
}
