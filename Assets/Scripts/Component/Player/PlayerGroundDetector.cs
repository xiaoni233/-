using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : PlayerComponent
{
    [SerializeField] float detectionRadius;
    //[SerializeField]
    public LayerMask groundLayer;
    //Collider[] colliders = new Collider[1];
    RaycastHit2D[] ray = new RaycastHit2D[1];

    public bool IsGrounded => Physics2D.RaycastNonAlloc(transform.position, Vector2.down, ray, detectionRadius) != 0;
    //Physics2D.LinecastNonAlloc(transform.position, tr, ray,groundLayer) != 0;
    //Physics2D.RaycastNonAlloc(transform.position, Vector2.down, ray,detectionRadius) != 0;
    //?????//Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;
    //private Vector3 tr=new Vector3(0,0,0);

    //private void Update()
    //{
    //    tr = new Vector3(transform.position.x, transform.position.y - detectionRadius, transform.position.z);
    //    Debug.Log(tr);
    //    Debug.Log(Physics2D.LinecastNonAlloc(transform.position, tr, ray, groundLayer));
    //    Debug.Log("isGtound" + IsGrounded);
    //    Debug.Log(Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer));
    //    Debug.Log(colliders[0]);
    //    Debug.Log(groundLayer.ToString());
    //    Debug.Log(detectionRadius);
    //    Debug.DrawLine(transform.position, tr);
    //}
    private void Update()
    {
        Debug.Log(IsGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        
    }

}
