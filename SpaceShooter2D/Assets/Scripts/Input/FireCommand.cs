using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command
{
    public override void Execute(PlayerScript pScript)
    {
        Instantiate(pScript.basicProjectile, transform.root);
    }
}
