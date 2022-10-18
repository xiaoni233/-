using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MyStateMachine
{
    [SerializeField] MyEnemyState[] states;
    Animator animator;
    public EnemyController enemyController;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        enemyController = GetComponentInChildren<EnemyController>();
        stateTable = new Dictionary<System.Type, IMyState>(states.Length);
        foreach (MyEnemyState state in states)
        {
            state.Initialize(animator, this, enemyController);
            stateTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SwitchOn(stateTable[typeof(EnemyState_Idle)]);
    }
}
