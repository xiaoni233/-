using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MyConponent
{
    public float wallCheckDistance;
    public LayerMask wallMask;
    public Vector2 direction;
    
    /// <summary>
    /// 返回有头朝向是否有墙壁
    /// </summary>
    public bool CheckWall()
    {
        return Physics2D.Raycast(transform.position, direction, wallCheckDistance, wallMask);
    }


    /// <summary>
    /// 编辑器 画出射线
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * wallCheckDistance));
    }
}
