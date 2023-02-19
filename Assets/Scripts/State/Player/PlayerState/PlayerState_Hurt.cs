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
        //���ܵ������ҳ�����ֱʱ�䣬���߳�������ʱ��,Ҫע������ʱ��Ҫ���ڽ�ֱʱ��
        if ((playerController.GetHit == false && StateDuration>playerController.hitStiffTime))
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }

    }

    public override void PhysicUpdate()
    {
        
    }
}
