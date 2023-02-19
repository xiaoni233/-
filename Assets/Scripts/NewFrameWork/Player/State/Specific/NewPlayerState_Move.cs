using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewPlayer/Move", fileName = "NewPlayerState_Move")]
public class NewPlayerState_Move : NewPlayerState
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
        if(player.isMove==false)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Idle));
        }
        if(player.isJump==true)
        {
            stateMachine.SwitchState(typeof(NewPlayerState_Jump));
        }
    }

    public override void PhysicUpdate()
    {

    }
}
