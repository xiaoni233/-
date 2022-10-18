using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerStateMachine :MyStateMachine
{
    [SerializeField] MyPlayerState[] states;
    Animator animator;
    MyPlayerController myPlayerController;
    PlayerInputMgr input ;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        myPlayerController = GetComponent<MyPlayerController>();
        stateTable = new Dictionary<System.Type, IMyState>(states.Length);
        input = PlayerInputMgr.GetInstance();
        foreach (MyPlayerState state in states)
        {
            state.Initialize(animator, this,myPlayerController);
            stateTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
