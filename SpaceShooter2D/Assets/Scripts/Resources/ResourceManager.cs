﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public float topDownMargin = 0.0f;
    public float leftRightMargin = 0.0f;

    private float topScreen = 0.0f;
    private float bottomScreen = 0.0f;
    private float leftScreen = 0.0f;
    private float rightScreen = 0.0f;

    private int score = 0;
    private int enemiesInScreen = 0;
    private int totalEnemiesPosible = 3;

    public int GetScore() { return score; }

    public void AddEnemy()
    {
        enemiesInScreen += 1;
    }

    public void EraseEnemy()
    {
        enemiesInScreen -= 1;
    }

    public void AddToScore(int amount)
    {
        score += amount;
    }

    private void Start()
    {
        score = 0;

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        topScreen = vertExtent - topDownMargin;
        bottomScreen = -vertExtent + topDownMargin;
        leftScreen = -horzExtent + leftRightMargin;
        rightScreen = horzExtent - leftRightMargin;
    }

    public Vector3 Rectify(Vector3 position)
    {
        if (position.x > rightScreen)
        {
            position.x = rightScreen;
        }
        else if (position.x < leftScreen)
        {
            position.x = leftScreen;
        }

        if (position.y < bottomScreen)
        {
            position.y = bottomScreen;
        }
        else if (position.y > topScreen)
        {
            position.y = topScreen;
        }

        return position;
    }


}
