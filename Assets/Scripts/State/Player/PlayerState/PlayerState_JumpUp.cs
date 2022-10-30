using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp :MyPlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        playerController.SetVelocityY(jumpForce);
    }
    public override void LogicUpdate()
    {
        if (playerController.GetHit&& (Time.time - myPlayerStateMachine.various.playerExitTime)
           > myPlayerStateMachine.various.playerHurtIntervalTime)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Hurt));
        }
        if (playerController.IsFalling||input.IsStopJump)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        playerController.Move(moveSpeed);
    }
}
