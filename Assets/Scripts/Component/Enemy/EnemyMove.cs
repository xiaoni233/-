using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyComponent
{
    public float speed;
    public float moveForce;

    protected override void Start()
    {
        base.Start();
    }

    public void ChangeDir()
    {
        if (controller.isOutRange)
        {
            transform.localScale = new Vector3(-controller.moveDir, transform.localScale.y, transform.localScale.z);
            controller.moveDir = -controller.moveDir;
        }
    }
    public void MoveBySpeed()
    {
        ChangeDir();
        controller.SetVelocityX(speed * controller.moveDir);
    }
}
