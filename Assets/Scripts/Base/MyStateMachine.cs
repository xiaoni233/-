using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStateMachine : MonoBehaviour
{
    IMyState currentState;
    protected Dictionary<System.Type, IMyState> stateTable;

    void Update()
    {
        currentState.LogicUpdate();
    }
    void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }
    protected void SwitchOn(IMyState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void SwitchState(IMyState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }
    public void SwitchState(System.Type newStateType)
    {
        SwitchState(stateTable[newStateType]);
    }
}
