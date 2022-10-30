using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCheck : MonoBehaviour
{
    public float ledgeCheckDistance;
    public LayerMask ledgeMask;
    public Vector2 direction;
    /// <summary>
    /// 返回有前方是否是悬崖
    /// </summary>
    public bool CheckLedge()
    {
        return Physics2D.Raycast(transform.position, direction, ledgeCheckDistance, ledgeMask);
    }
    /// <summary>
    /// 编辑器 画出射线
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * ledgeCheckDistance));
    }
}
