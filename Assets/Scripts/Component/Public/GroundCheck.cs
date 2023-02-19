using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundCheckDistance;
    public LayerMask groundMask;
    public Vector2 direction;

    /// <summary>
    /// �����棬������������
    /// </summary>
    public bool CheckGround()
    {
        return Physics2D.Raycast(transform.position, direction, groundCheckDistance, groundMask);
    }
    /// <summary>
    /// ��������������
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public bool CheckGround(float distance)
    {
        return Physics2D.Raycast(transform.position, direction, distance, groundMask);
    }


    /// <summary>
    /// �༭�� ��������
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * groundCheckDistance));
    }
}
