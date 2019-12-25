using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearState : EnemyState
{
    private bool done = false;
    private float lambda = 0.0f;
    private float timer = 0.0f;

    public override void UpdateState()
    {
        timer += Time.deltaTime;

        lambda = timer / enemy.appearDuration;

        if(lambda <= 1.0f)
        {
            enemy.gameObject.transform.position = Vector3.Lerp(enemy.GetSpawnPos(), enemy.GetFirstPos(), lambda);
        }
        else
        {
            done = true;
        }
    }

    public override void ChangeState()
    {
        if(done)
        {
            enemy.SetStateTo(enemy.GetAttackState());
        }
    }
}
