using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewEnemy/Attack", fileName = "NewEnemyState_Attack")]
public class NewEnemyState_Attack : NewEnemyStates
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
        if(enmey.isAttack==false)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Idle));
        }
    }

    public override void PhysicUpdate()
    {

    }
}