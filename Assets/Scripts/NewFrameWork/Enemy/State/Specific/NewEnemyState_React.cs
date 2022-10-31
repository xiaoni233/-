using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewEnemy/React", fileName = "NewEnemyState_React")]
public class NewEnemyState_React : NewEnemyStates
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
        if (enmey.isAttackReady)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Attack));
        }
    }

    public override void PhysicUpdate()
    {

    }
}