using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Hurt", fileName = "PlayerState_Hurt")]
public class PlayerState_Hurt : MyPlayerState
{
    private AnimatorStateInfo info;
    public override void Enter()
    {
        base.Enter();
        playerController.healthValue--;
    }

    public override void Exit()
    {
        PlayerVarious.GetInstance().playerExitTime = Time.time;
    }

    public override void LogicUpdate()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 0.9f)
        {
            playerController.SetgetHit(false);
        }
        //不受到攻击且超过僵直时间，或者超过受伤时间,要注意受伤时间要大于僵直时间
        if ((playerController.GetHit == false && StateDuration>playerController.hitStiffTime))
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }

    }

    public override void PhysicUpdate()
    {
        
    }
}
