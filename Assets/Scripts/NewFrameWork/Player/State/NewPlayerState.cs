using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerState : ScriptableObject, IMyState
{
    protected Animator animator;
    protected NewPlayerStateMachine stateMachine;
    protected NewPlayerController player;
    protected AnimatorStateInfo info ;

    [SerializeField] string stateName;
    int stateHash;
    float stateStartTime;
    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f;

    public void Initialize(Animator animator, NewPlayerStateMachine myStateMachine, NewPlayerController playerController)
    {
        this.animator = animator;
        this.stateMachine = myStateMachine;
        this.player = playerController;
       
    }
    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
       
    }

    public virtual void LogicUpdate()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
