﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardioid : Curve
{
    private float consA = 0.8f;
    private float consB = 1.5f;
    private float consC = 1.5f;

    public override Vector3 FollowCurve(float alpha, Vector3 center)
    {
        float newRadius = consA + consB * Mathf.Sin(alpha);
        float newX = consC * (center.x + newRadius * Mathf.Cos(alpha));
        float newY = center.y + newRadius * Mathf.Sin(alpha);

        Vector3 newPosition = new Vector3(newX, newY, 0.0f);

        return newPosition;
    }
}
