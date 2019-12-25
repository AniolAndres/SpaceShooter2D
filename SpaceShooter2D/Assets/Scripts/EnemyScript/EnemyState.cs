using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public virtual void SetEnemy(BasicEnemy enemyScript)
    {
        enemy = enemyScript;
    }

    protected BasicEnemy enemy;

    public virtual void UpdateState() { }
    public virtual void ChangeState() { }
    public virtual void Exit() { }
    public virtual void Enter() { }
}
