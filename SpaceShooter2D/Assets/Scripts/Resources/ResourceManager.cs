using System.Collections;
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

    private void Start()
    {
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
