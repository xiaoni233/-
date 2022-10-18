using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Hit", fileName = "EnemyState_Hit")]
public class EnemyState_Hit : MyEnemyState
{
    private AnimatorStateInfo info;
    public override void Enter()
    {
        base.Enter();
        enemyController.health--;
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime>=0.9f)
        {
            enemyController.getHit = false;
        }
        if(enemyController.getHit==false)
        {
            stateMachine.SwitchState(typeof(EnemyState_Idle));
        }
        if(enemyController.health<=0)
        {
            stateMachine.SwitchState(typeof(EnemyState_Dead));
        }
    }

    public override void PhysicUpdate()
    {

    }

}

