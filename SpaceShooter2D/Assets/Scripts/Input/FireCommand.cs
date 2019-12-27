using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command
{
    private Vector3 deviation = new Vector3(0.4f,0.0f,0.0f);


    public override void Execute(PlayerScript pScript)
    {
        if(pScript.IsProjReady() && pScript.currentHP > 0)
        {
            if (pScript.IsBoosted())
            {
                GameObject proj1 = Instantiate(pScript.basicProjectile, pScript.gameObject.transform.position + deviation, Quaternion.identity);
                BasicProjectile projScript1 = proj1.GetComponent<BasicProjectile>();
                projScript1.SetSpeed(pScript.GetBaseProjSpeed());
                projScript1.SetDamage(pScript.GetBaseProjDamage());

                GameObject proj2 = Instantiate(pScript.basicProjectile, pScript.gameObject.transform.position - deviation, Quaternion.identity);
                BasicProjectile projScript2 = proj2.GetComponent<BasicProjectile>();
                projScript2.SetSpeed(pScript.GetBaseProjSpeed());
                projScript2.SetDamage(pScript.GetBaseProjDamage());

            }
            else
            {
                GameObject proj = Instantiate(pScript.basicProjectile, pScript.gameObject.transform.position, Quaternion.identity);
                BasicProjectile projScript = proj.GetComponent<BasicProjectile>();
                projScript.SetSpeed(pScript.GetBaseProjSpeed());
                projScript.SetDamage(pScript.GetBaseProjDamage());
            }

            pScript.PlayShotAudio();

            pScript.SetProjReady(false);
        }
    }
}
