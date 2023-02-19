using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyStateMachine : MyStateMachine
{
    NewEnemyController controller;
    [SerializeField] NewEnemyStates[] states;
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<NewEnemyController>();
        stateTable = new Dictionary<System.Type, IMyState>(states.Length);
        foreach (NewEnemyStates state in states)
        {
            state.Initialize(animator, this, controller);
            stateTable.Add(state.GetType(), state);
        }
        SwitchOn(stateTable[typeof(NewEnemyState_Idle)]);
    }

}
