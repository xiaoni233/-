using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land :MyPlayerState
{
    public override void Enter()
    {
        playerController.SetVelocity(Vector3.zero);
        playerController.CanAirJump = true;
    }

    public override void LogicUpdate()
    {
        if(input.IsJump)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if(StateDuration<stiffTime)
        {
            return;
        }
        if(IsAnimationFinished)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
}
