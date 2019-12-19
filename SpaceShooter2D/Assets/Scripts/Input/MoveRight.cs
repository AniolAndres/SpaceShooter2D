using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Command
{
    public override void Execute(PlayerScript pScript)
    {
        pScript.MoveRight(1.0f);
    }

    public override void Stop(PlayerScript pScript)
    {
        pScript.MoveRight(0.0f);
    }
}
