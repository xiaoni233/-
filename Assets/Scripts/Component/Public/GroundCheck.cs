using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundCheckDistance;
    public LayerMask groundMask;
    public Vector2 direction;

    /// <summary>
    /// 检测地面，距离由面板分配
    /// </summary>
    public bool CheckGround()
    {
        return Physics2D.Raycast(transform.position, direction, groundCheckDistance, groundMask);
    }
    /// <summary>
    /// 参数可输入重载
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public bool CheckGround(float distance)
    {
        return Physics2D.Raycast(transform.position, direction, distance, groundMask);
    }


    /// <summary>
    /// 编辑器 画出射线
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * groundCheckDistance));
    }
}
