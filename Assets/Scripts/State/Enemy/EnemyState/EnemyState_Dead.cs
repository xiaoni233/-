using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Dead", fileName = "EnemyState_Dead")]
public class EnemyState_Dead : MyEnemyState
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
        if(enemyController.health>0)
        {
            stateMachine.SwitchState(typeof(EnemyState_Idle));
        }
    }

    public override void PhysicUpdate()
    {

    }

}

