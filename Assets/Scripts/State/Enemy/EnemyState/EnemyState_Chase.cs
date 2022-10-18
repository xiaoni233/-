using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Chase", fileName = "EnemyState_Chase")]
public class EnemyState_Chase : MyEnemyState
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
        enemyController.FlipTo(enemyController.target);
        if (enemyController.getHit)
        {
            stateMachine.SwitchState(typeof(EnemyState_Hit));
        }
        if (enemyController.target)
        {
            enemyController.transform.position = Vector2.MoveTowards(enemyController.transform.position,
      enemyController.target.position,enemyController.chaseSpeed * Time.deltaTime);
        }
        if (enemyController.target == null ||
          enemyController.target.position.x < enemyController.chasePoints[0].position.x ||
         enemyController.target.position.x > enemyController.chasePoints[1].position.x)
        {
            stateMachine.SwitchState(typeof(EnemyState_Idle));
        }
        if(Physics2D.OverlapCircle(enemyController.attackPoint.position,enemyController.attackArea,enemyController.targetLayer))
        {
            Debug.Log("attack ok");
            stateMachine.SwitchState(typeof(EnemyState_Attack));
        }

    }

    public override void PhysicUpdate()
    {

    }

}
