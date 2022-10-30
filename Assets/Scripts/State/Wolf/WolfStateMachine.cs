using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStateMachine : MyStateMachine
{
    [SerializeField] WolfStates[] states;
    Animator animator;
    public WolfController wolf;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        wolf = GetComponentInChildren<WolfController>();
        stateTable = new Dictionary<System.Type, IMyState>(states.Length);
        foreach (WolfStates state in states)
        {
            state.Initialize(animator, this, wolf);
            stateTable.Add(state.GetType(), state);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchOn(stateTable[typeof(WolfState_Patrol)]);
    }

}
