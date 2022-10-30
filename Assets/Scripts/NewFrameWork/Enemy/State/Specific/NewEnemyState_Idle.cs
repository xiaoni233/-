using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/NewEnemy/Idle", fileName = "NewEnemyState_Idle")]
public class NewEnemyState_Idle : NewEnemyStates
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
        if(enmey.isHit)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Hit));
        }
        if (enmey.isReact)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_React));
        }
        if (enmey.isMove)
        {
            stateMachine.SwitchState(typeof(NewEnemyState_Walk));
        }
       
        
    }

    public override void PhysicUpdate()
    {
        
    }
}
