using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemniscata : Curve
{
    private float consA = 1.2f;
    private float consB = 2.0f;
    private float consC = 1.5f;

    public override Vector3 FollowCurve(float alpha, Vector3 center)
    {
        float newRadius = 0.0f;

        if (Mathf.Cos(alpha * consB) < 0.0f)
        {
            newRadius = - Mathf.Sqrt(Mathf.Abs(consA * consA * Mathf.Cos(alpha * consB)));
        }
        else
        {
            newRadius = Mathf.Sqrt(Mathf.Abs(consA * consA * Mathf.Cos(alpha * consB)));
        }

        float newX = consC * (center.x + newRadius * Mathf.Cos(alpha));
        float newY = consC * (center.y + newRadius * Mathf.Sin(alpha));

        Vector3 newPosition = new Vector3(newX, newY, 0.0f);

        return newPosition;
    }
}
