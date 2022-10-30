using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Idle",fileName ="PlayerState_Idle")]
public class PlayerState_Idle :MyPlayerState
{
    [SerializeField] float deceleration = 5f;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = playerController.MoveSpeed;
        myPlayerStateMachine.various.isAttackReady = true;
    }
    public override void LogicUpdate()
    {      
        if(playerController.GetHit&&(Time.time - myPlayerStateMachine.various.playerExitTime)
           > myPlayerStateMachine.various.playerHurtIntervalTime)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Hurt));
        }
       if(input.IsMove)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
       if(input.IsJump)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
       if(!playerController.IsGrounded)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        playerController.SetVelocityX(currentSpeed * playerController.transform.localScale.x);
    }

}
