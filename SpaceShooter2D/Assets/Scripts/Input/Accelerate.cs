using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : Command
{
    public override void Execute(PlayerScript pScript)
    {
        pScript.MoveForward(1.0f);
    }

    public override void Stop(PlayerScript pScript)
    {
        pScript.MoveForward(0.0f);
    }
}
