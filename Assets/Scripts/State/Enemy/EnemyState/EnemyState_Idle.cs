using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Idle", fileName = "EnemyState_Idle")]
public class EnemyState_Idle :MyEnemyState
{
    private float timer;
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        timer = 0;
    }

    public override void LogicUpdate()
    {
        timer += Time.deltaTime;
       if(enemyController.GetHit)
        {
            stateMachine.SwitchState(typeof(EnemyState_Hit));
        }
        if (enemyController.target != null &&
            enemyController.target.position.x >= enemyController.chasePoints[0].position.x &&
           enemyController.target.position.x <= enemyController.chasePoints[1].position.x)
        {
            stateMachine.SwitchState(typeof(EnemyState_React));
        }
        if (timer >= enemyController.idleTime)
        {
            stateMachine.SwitchState(typeof(EnemyState_Walk));
            return;
        }

    }

    public override void PhysicUpdate()
    {
        
    }

}
