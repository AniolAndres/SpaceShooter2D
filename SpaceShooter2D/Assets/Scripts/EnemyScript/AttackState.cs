using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    private float shotTimer = 0.0f;

    public override void UpdateState()
    {
        if(shotTimer > enemy.GetEC().shotCD)
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

        enemy.gameObject.transform.position = enemy.GetCurve().FollowCurve(enemy.GetAlpha(), enemy.GetCurveCenter());
    }
}
