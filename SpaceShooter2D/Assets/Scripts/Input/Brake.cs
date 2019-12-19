using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : Command
{
    public override void Execute(PlayerScript pScript)
    {
        pScript.MoveDown(1.0f);
    }

    public override void Stop(PlayerScript pScript)
    {
        pScript.MoveDown(0.0f);
    }
}
