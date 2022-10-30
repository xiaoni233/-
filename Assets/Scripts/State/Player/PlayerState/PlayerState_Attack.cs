using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//已经弃用
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Attack", fileName = "PlayerState_Attack")]
public class PlayerState_Attack : MyPlayerState
{
    private AnimatorStateInfo info;
    private int comboCount;
    private float timer;
    private bool isLightAttack =>Input.GetKey(KeyCode.J);
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (playerController.GetHit)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Hurt));
        }
        Attack();
        //碰撞检测到，并触发敌人伤害函数
        //if (playerController.hitBox.IsObjHurt("Enemy"))
        //{
        //    MyEventCenter.GetInstance().EventTrigger("EnemyHurt");
        //}
        if(info.normalizedTime>=0.95f)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }

    public override void PhysicUpdate()
    {
       
    }

    private void Attack()
    {
       
        //if (isLightAttack&&playerController.isAttackReady)
        //{
        //    playerController.isAttackReady = false;
        //    comboCount++;
        //    timer = playerController.interval;
        //    animator.SetTrigger("LightAttack");
        //    animator.SetInteger("ComboCount", comboCount);
        //    if (timer != 0)
        //    {
        //        timer -= Time.deltaTime;
        //        if (timer <= 0)
        //        {
        //            timer = 0;
        //            comboCount = 0;
        //        }
        //    }
        //}
    }
   
}
