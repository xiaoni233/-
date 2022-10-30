using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : MyPlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = playerController.MoveSpeed;
    }
    public override void LogicUpdate()
    {
        if (playerController.GetHit&&(Time.time - myPlayerStateMachine.various.playerExitTime)
           > myPlayerStateMachine.various.playerHurtIntervalTime)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Hurt));
        }
        if (!input.IsMove)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if(input.IsJump)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if(input.IsDash)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Dash));
        }
        if(input.IsDash)
        {
            if(Time.time>=(playerController.lastDash+playerController.dashCoolDown))
            {
                myPlayerStateMachine.SwitchState(typeof(PlayerState_Dash));
            }
        }
        if(!playerController.IsGrounded)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }       
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        playerController.Move(currentSpeed);
    }
}
