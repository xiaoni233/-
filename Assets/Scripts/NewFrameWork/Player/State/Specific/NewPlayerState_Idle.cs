using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewPlayer/Idle", fileName = "NewPlayerState_Idle")]
public class NewPlayerState_Idle : NewPlayerState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
      
    }

    public override void LogicUpdate()
    {
        if(player.isMove)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Move));
        }
        if(player.isJump)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Jump));
        }
    }

    public override void PhysicUpdate()
    {
        
    }
}
