using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerComponent
{
    public float jumpForce;
    public float jumpSpeed;//注意正负有方向
    public float fallSpeed;//负为下
    protected override void Start()
    {
        base.Start();
    }
    public void Jump()
    {
        Vector2 force = new Vector2(0f, jumpForce);
        controller.Rb.AddForce(force);
    }
    public  void JumpBySetVelocityY()
    {
        controller.SetVelocityY(jumpSpeed);
    }
    public void FallVelocityY()
    {
        controller.SetVelocityY(fallSpeed);
    }
    public void FallByGravityScale(float scale)
    {
        controller.Rb.gravityScale = scale;
    }
}
