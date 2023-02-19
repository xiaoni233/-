using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerStateMachine : MyStateMachine
{
    NewPlayerController controller;
    [SerializeField] NewPlayerState[] states;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<NewPlayerController>();
        stateTable = new Dictionary<System.Type, IMyState>(states.Length);
        foreach (NewPlayerState state in states)
        {
            state.Initialize(animator, this, controller);
            stateTable.Add(state.GetType(), state);
        }
        SwitchOn(stateTable[typeof(NewPlayerState_Idle)]);
    }

}
