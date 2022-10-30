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
        enemyController.SetVelocityX(enemyController.getHitSpeed*
            PlayerVarious.GetInstance().playerController.transform.localScale.x);
}

    public override void Exit()
    {
        enemyController.SetVelocityX(0f);
    }

    public override void LogicUpdate()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime>=0.9f)
        {
            enemyController.SetgetHit(false);
        }
        if(enemyController.GetHit==false)
        {
            stateMachine.SwitchState(typeof(EnemyState_Idle));
        }
        if(enemyController.health<=0)
        {
            enemyController.BoxCollider2D.enabled = false;
            enemyController.CircleCollider.enabled = false;
            enemyController.SetVelocityX(0f);
            stateMachine.SwitchState(typeof(EnemyState_Dead));
        }
    }

    public override void PhysicUpdate()
    {

    }

}

