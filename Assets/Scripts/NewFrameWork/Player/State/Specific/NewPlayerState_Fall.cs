using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewPlayer/Fall", fileName = "NewPlayerState_Fall")]
public class NewPlayerState_Fall : NewPlayerState
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
        if(player.isLand)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Land));
        }
    }

    public override void PhysicUpdate()
    {
        
    }
}
