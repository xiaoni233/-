using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Walk", fileName = "EnemyState_Walk")]
public class EnemyState_Walk : MyEnemyState
{
    private int partrolPosition;
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        partrolPosition++;
        if(partrolPosition>=enemyController.patrolPoints.Length)
        {
            partrolPosition = 0;
        }
    }

    public override void LogicUpdate()
    {
        enemyController.FlipTo(enemyController.patrolPoints[partrolPosition]);
        if (enemyController.GetHit)
        {
            stateMachine.SwitchState(typeof(EnemyState_Hit));
        }
        enemyController.transform.position = Vector2.MoveTowards(enemyController.transform.position,
        enemyController.patrolPoints[partrolPosition].position,
        enemyController.MoveSpeed * Time.deltaTime);

        if (enemyController.target != null &&
           enemyController.target.position.x >= enemyController.chasePoints[0].position.x &&
          enemyController.target.position.x <= enemyController.chasePoints[1].position.x)
        {
            stateMachine.SwitchState(typeof(EnemyState_React));
        }
        if (Vector2.Distance(enemyController.transform.position,enemyController.patrolPoints[partrolPosition].position)<0.5f)
        {
            stateMachine.SwitchState(typeof(EnemyState_Idle));
        }
    }

    public override void PhysicUpdate()
    {
        
    }

}
