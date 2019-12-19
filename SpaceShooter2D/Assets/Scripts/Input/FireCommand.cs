using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command
{
    private float cdTimer = 0.0f;

    public override void Execute(PlayerScript pScript)
    {
        if(cdTimer > pScript.GetBaseProjCD())
        {
            GameObject proj = Instantiate(pScript.basicProjectile, pScript.gameObject.transform.position, Quaternion.identity);
            BasicProjectile projScript = proj.GetComponent<BasicProjectile>();

            projScript.SetSpeed(pScript.GetBaseProjSpeed());
            projScript.SetDamage(pScript.GetBaseProjDamage());

            cdTimer = 0.0f;
        }
        else
        {
            cdTimer += Time.deltaTime;
        }

       
    }
}
