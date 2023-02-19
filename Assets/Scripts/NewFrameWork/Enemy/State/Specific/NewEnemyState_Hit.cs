using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewEnemy/Hit", fileName = "NewEnemyState_Hit")]
public class NewEnemyState_Hit : NewEnemyStates
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
        if(enmey.isDead)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Dead));
        }
       
        if (enmey.isRecover)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Idle));
        }
    }

    public override void PhysicUpdate()
    {

    }
}