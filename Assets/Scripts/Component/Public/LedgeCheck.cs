using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCheck : MonoBehaviour
{
    public float ledgeCheckDistance;
    public LayerMask ledgeMask;
    public Vector2 direction;
    /// <summary>
    /// ������ǰ���Ƿ�������
    /// </summary>
    public bool CheckLedge()
    {
        return Physics2D.Raycast(transform.position, direction, ledgeCheckDistance, ledgeMask);
    }
    /// <summary>
    /// �༭�� ��������
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * ledgeCheckDistance));
    }
}
