using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent :MyConponent
{
    protected NewEnemyController controller;
    protected virtual void Start()
    {
        controller = GetComponentInParent<NewEnemyController>();
    }
}
