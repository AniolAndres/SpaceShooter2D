using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command
{
    public override void Execute(PlayerScript pScript)
    {
        if(pScript.IsProjReady())
        {
            GameObject proj = Instantiate(pScript.basicProjectile, pScript.gameObject.transform.position, Quaternion.identity);
            BasicProjectile projScript = proj.GetComponent<BasicProjectile>();

            projScript.SetSpeed(pScript.GetBaseProjSpeed());
            projScript.SetDamage(pScript.GetBaseProjDamage());
            pScript.SetProjReady(false);
        }
    }
}
