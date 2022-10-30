using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewPlayer/Land", fileName = "NewPlayerState_Land")]
public class NewPlayerState_Land : NewPlayerState
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
        base.LogicUpdate();
        if(info.normalizedTime >= 0.9f)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Idle));
        }
    }

    public override void PhysicUpdate()
    {
        
    }
}
