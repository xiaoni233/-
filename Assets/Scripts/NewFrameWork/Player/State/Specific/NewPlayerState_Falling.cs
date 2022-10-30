using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/NewPlayer/Falling", fileName = "NewPlayerState_Falling")]
public class NewPlayerState_Falling : NewPlayerState
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
        if(player.isFall)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
       
    }
}
