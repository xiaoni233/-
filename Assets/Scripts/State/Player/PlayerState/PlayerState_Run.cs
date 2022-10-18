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
        if (input.IsAttack)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Attack));
        }
        if (!input.IsMove)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if(input.IsJump)
        {
            myPlayerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
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
