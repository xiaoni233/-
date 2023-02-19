using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerState : ScriptableObject, IMyState
{
    [Header("ʱ��")]
    [SerializeField]protected float stiffTime = 0.2f;
    float stateStartTime; 
    protected float StateDuration => Time.time - stateStartTime;
    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f;

    [Header("��������")]
    [SerializeField] string stateName;
    int stateHash;
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    
    [Header("���")]
    protected Animator animator;
    protected MyPlayerStateMachine myPlayerStateMachine;
    protected MyPlayerController playerController;
    protected PlayerInputMgr input;

    protected float currentSpeed;

    public void Initialize(Animator animator,MyPlayerStateMachine myStateMachine,MyPlayerController playerController)
    {
        this.animator = animator;
        this.myPlayerStateMachine = myStateMachine;
        this.playerController = playerController;
        input= PlayerInputMgr.GetInstance();
    }
    void OnEnable()//??????û�м̳�MonoBehaviourΪʲô���ã�
    {
        stateHash = Animator.StringToHash(stateName);
        //Debug.Log("OnEnable in PlayerState");
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
