using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 direction = new Vector3(0.0f, 1.0f, 0.0f);

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }
}
