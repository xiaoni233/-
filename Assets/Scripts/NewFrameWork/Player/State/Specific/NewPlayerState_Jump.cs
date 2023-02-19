using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewPlayer/Jump", fileName = "NewPlayerState_Jump")]
public class NewPlayerState_Jump : NewPlayerState
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
       if(player.isFalling)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Falling));
        }
    }

    public override void PhysicUpdate()
    {
        
    }
}
