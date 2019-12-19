using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command
{
    public override void Execute(PlayerScript pScript)
    {
        pScript.MoveLeft(1.0f);
    }

    public override void Stop(PlayerScript pScript)
    {
        pScript.MoveLeft(0.0f);
    }
}
