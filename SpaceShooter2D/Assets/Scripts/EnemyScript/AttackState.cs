using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    private float shotInterval = 0.8f;
    private float shotTimer = 0.0f;

    public override void UpdateState()
    {
        if(shotTimer > shotInterval)
        {
            enemy.SpawnProjectile();
            shotTimer = 0.0f;
        }
        else
        {
            shotTimer += Time.deltaTime;
        }

        enemy.SetAlpha(enemy.GetAlpha() + enemy.GetEC().speed * Time.deltaTime);

        if(enemy.GetAlpha() > Mathf.PI * 2)
        {
            enemy.SetAlpha(enemy.GetAlpha() - Mathf.PI * 2);
        }

        enemy.gameObject.transform.position = enemy.GetCurve().FollowCurve(enemy.GetAlpha(), enemy.consA, enemy.consB,
            enemy.consC, enemy.GetCurveCenter());
    }

    public override void ChangeState()
    {

    }
}
