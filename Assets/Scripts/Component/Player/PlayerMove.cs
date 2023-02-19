using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerComponent
{

    public float speed;
   // public float airSpeed;
    public float moveForce;
    protected override void Start()
    {
        base.Start();
    }

    public void Move()
    {
        ChangeDir();
        controller.SetVelocityX(speed * controller.moveDir);
    }
    public void Move(float moveSpeed)
    {
        ChangeDir();
        controller.SetVelocityX(moveSpeed * controller.moveDir);
    }
    public void MoveXByForce(float force)
    {
        ChangeDir();
        controller.SetForceX(force*controller.moveDir);        
    }
    public void MoveXByForce()
    {
        ChangeDir();
        controller.SetForceX(moveForce * controller.moveDir);
    }
    public void PauseMove()
    {
        controller.SetVelocityX(0f);
    }

    public void ChangeDir()
    {
        if (controller.Input.AxesX != 0)
        {
            controller.moveDir = Mathf.Abs(controller.Input.AxesX) * (1 / controller.Input.AxesX);
        }
        if (controller.Input.IsMove)
        {
            transform.localScale = new Vector3(controller.moveDir, 1f, 1f);
        }
    }
}
