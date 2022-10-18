using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMyState 
{
    void Enter();
    void Exit();
    void LogicUpdate();
    void PhysicUpdate();
}
