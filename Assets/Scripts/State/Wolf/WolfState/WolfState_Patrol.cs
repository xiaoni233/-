using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/WolfState/Patrol", fileName = "WolfState_Patrol")]
public class WolfState_Patrol : WolfStates
{
    private int partrolPosition=0;
    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {

        wolf.FlipTo(wolf.patrolPoints[partrolPosition]);
        wolf.transform.position = Vector2.MoveTowards(wolf.transform.position,
          wolf.patrolPoints[partrolPosition].position,
          wolf.MoveSpeed * Time.deltaTime);
        if(Vector2.Distance(wolf.transform.position,wolf.patrolPoints[partrolPosition].position)<2f)
        {
            ChangePoint();
        }
        
    }
    private void ChangePoint()
    {
        partrolPosition++;
        if(partrolPosition>=wolf.patrolPoints.Length)
        {
            partrolPosition = 0;
        }
    }

}
