using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/React", fileName = "EnemyState_React")]
public class EnemyState_React : MyEnemyState
{
    private AnimatorStateInfo info;
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {
        if (enemyController.GetHit)
        {
            stateMachine.SwitchState(typeof(EnemyState_Hit));
        }
        enemyController.FlipTo(enemyController.target);
        info = animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime>=0.95f)
        {
            stateMachine.SwitchState(typeof(EnemyState_Chase));
        }
    }

    public override void PhysicUpdate()
    {

    }

}

