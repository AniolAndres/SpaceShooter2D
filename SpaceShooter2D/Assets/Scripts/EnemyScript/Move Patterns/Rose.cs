using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : Curve
{
    private float consA = 1.0f;
    private float consB = 3.0f;
    private float consC = 1.5f;

    public override Vector3 FollowCurve(float alpha, Vector3 center)
    {
        float newRadius = consA * Mathf.Sin(alpha * consB);
        float newX = consC * (center.x + newRadius * Mathf.Cos(alpha));
        float newY = consC* (center.y + newRadius * Mathf.Sin(alpha));

        Vector3 newPosition = new Vector3(newX, newY, 0.0f);

        return newPosition;
    }
}
