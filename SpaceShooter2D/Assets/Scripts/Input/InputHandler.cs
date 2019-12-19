using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Command buttonW = new Accelerate();
    private Command buttonA = new MoveLeft();
    private Command buttonS = new Brake();
    private Command buttonD = new MoveRight();
    private Command buttonSpace = new FireCommand();

    public PlayerScript pScript;

    private void HandleInput()
    {
        if (Input.GetKey("w")) buttonW.Execute(pScript);
        else buttonW.Stop(pScript);

        if (Input.GetKey("a")) buttonA.Execute(pScript);
        else buttonA.Stop(pScript);

        if (Input.GetKey("s")) buttonS.Execute(pScript);
        else buttonS.Stop(pScript);

        if (Input.GetKey("d")) buttonD.Execute(pScript);
        else buttonD.Stop(pScript);

        if (Input.GetKey("space")) buttonSpace.Execute(pScript);
        else buttonSpace.Stop(pScript);

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
