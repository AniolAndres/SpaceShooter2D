﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public virtual void SetEnemy(BasicEnemy enemyScript)
    {
        enemy = enemyScript;
    }

    protected BasicEnemy enemy;

    //This function will handle the state change
    public virtual void UpdateState() { }
    //this function will update the actual state
    public virtual void ChangeState() { }
    public virtual void Exit() { }
    public virtual void Enter() { }
}
