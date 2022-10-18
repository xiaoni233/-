using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJump", fileName = "PlayerState_AirJump")]
public class PlayerState_AirJump : MyPlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        playerController.CanAirJump = false;
        playerController.SetVelocityY(jumpForce);
    }
    public override void LogicUpdate()
    {
        if (playerController.IsFalling || input.IsStopJump)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        playerController.Move(moveSpeed);
    }
}
