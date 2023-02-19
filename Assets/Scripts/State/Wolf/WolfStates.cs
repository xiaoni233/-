using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStates : ScriptableObject, IMyState
{
    [Header("���")]
    protected WolfStateMachine stateMachine;
    protected WolfController wolf;
    protected Animator animator;

    [Header("��������")]
    [SerializeField] string stateName;
    int stateHash;
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    [Header("ʱ��")]
    [SerializeField] protected float stiffTime = 0.2f;
    float stateStartTime;
    protected float StateDuration => Time.time - stateStartTime;
    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f;

    public void Initialize(Animator animator, WolfStateMachine wolfStateMachine, WolfController wolf)
    {
        this.animator = animator;
        this.wolf=wolf;
        this.stateMachine = wolfStateMachine;
    }
    void OnEnable()
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
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
