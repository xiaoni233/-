using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dash", fileName = "PlayerState_Dash")]
public class PlayerState_Dash : MyPlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerController.dashTimeLeft = playerController.dashTime;
        playerController.lastDash = Time.time;
    }

    public override void Exit()
    {
        playerController.SetVelocityX(0);
    }

    public override void LogicUpdate()
    {
        if (playerController.dashTimeLeft > 0)
        {
            playerController.BoxCollider2D.enabled = false;
            playerController.CircleCollider.enabled = false;
            playerController.Rigidbody2D.gravityScale = 0;
            playerController.SetVelocityX(playerController.dashSpeed*playerController.moveDir);
            playerController.dashTimeLeft -= Time.deltaTime;
            ShadowPool.instance.GetFormPool();
        }
        else
        {
            playerController.BoxCollider2D.enabled = true;
            playerController.CircleCollider.enabled = true;
            playerController.Rigidbody2D.gravityScale = 1;
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }

    public override void PhysicUpdate()
    {
       
    }
}
