using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall :MyPlayerState
{
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float moveSpeed = 5f;
    public override void LogicUpdate()
    {
        if(playerController.IsGrounded)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Land));
        }
        if(input.IsJump)
        {
            if(playerController.CanAirJump)
            {
                myPlayerStateMachine.SwitchState(typeof(PlayerState_AirJump));
            }
        }
    }
    public override void PhysicUpdate()
    {
        playerController.SetVelocityY(speedCurve.Evaluate(StateDuration));
        playerController.Move(moveSpeed);
    }
}
