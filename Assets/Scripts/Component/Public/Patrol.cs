using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MyConponent
{
    public GameObject patrolPointL;
    public GameObject patrolPointR;

    private Transform tr;
    private void Awake()
    {
        tr = GetComponentInParent<Transform>();
    }
    /// <summary>
    /// �����Ƿ񳬹�Ѳ�ߵ㣬������ҷ���false
    /// </summary>
    /// <returns></returns>
    public bool PatrolCheckXIn()
    {
        return tr.transform.position.x < patrolPointR.transform.position.x &&
            tr.transform.position.x > patrolPointL.transform.position.x;
    }
    
    public bool PatrolAtLPoint()
    {
        return tr.transform.position.x ==patrolPointL.transform.position.x;
    }
    public bool PatrolAtRPoint()
    {
        return tr.transform.position.x == patrolPointR.transform.position.x;
    }

}
