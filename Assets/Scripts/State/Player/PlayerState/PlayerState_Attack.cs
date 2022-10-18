using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Attack", fileName = "PlayerState_Attack")]
public class PlayerState_Attack : MyPlayerState
{
    private AnimatorStateInfo info;
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime>=0.95f)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }

    public override void PhysicUpdate()
    {
       
    }
}
