using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewEnemy/Walk", fileName = "NewEnemyState_Walk")]
public class NewEnemyState_Walk : NewEnemyStates
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
        if (enmey.isHit)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Hit));
        }
        if (enmey.isReact)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_React));
        }
        if(enmey.isIdle)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Idle));
        }
    }

    public override void PhysicUpdate()
    {

    }
}
