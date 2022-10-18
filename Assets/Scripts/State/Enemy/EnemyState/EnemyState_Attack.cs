using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Attack", fileName = "EnemyState_Attack")]
public class EnemyState_Attack : MyEnemyState
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
        Debug.Log("e hit logicUpdate"+enemyController.getHit);
        if (enemyController.getHit)
        {
            stateMachine.SwitchState(typeof(EnemyState_Hit));
        }
        if (!(Physics2D.OverlapCircle(enemyController.attackPoint.position, enemyController.attackArea, enemyController.targetLayer)))
        {
            stateMachine.SwitchState(typeof(EnemyState_Chase));
        }
    }

    public override void PhysicUpdate()
    {

    }

}

