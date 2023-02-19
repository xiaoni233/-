using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MyConponent
{
    public float wallCheckDistance;
    public LayerMask wallMask;
    public Vector2 direction;
    
    /// <summary>
    /// ������ͷ�����Ƿ���ǽ��
    /// </summary>
    public bool CheckWall()
    {
        return Physics2D.Raycast(transform.position, direction, wallCheckDistance, wallMask);
    }


    /// <summary>
    /// �༭�� ��������
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * wallCheckDistance));
    }
}
