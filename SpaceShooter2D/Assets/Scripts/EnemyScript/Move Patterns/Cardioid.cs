using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardioid : Curve
{
    public override Vector3 FollowCurve(float alpha, float a, float b, float c, Vector3 center)
    {
        float newRadius = a + b * Mathf.Sin(alpha);
        float newX = center.x + newRadius * Mathf.Cos(alpha);
        float newY = center.y + newRadius * Mathf.Sin(alpha);

        Vector3 newPosition = new Vector3(newX, newY, 0.0f);

        return newPosition;
    }
}
