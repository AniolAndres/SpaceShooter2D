using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public int damage = 0;
    public float speed = 1.0f;
    public float rotationSpeed = 50.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Will damage player and destroy enemies

        if (collision.gameObject.tag == "Player")
        {
            PlayerScript pScript = collision.gameObject.GetComponent<PlayerScript>();

            pScript.DamagePlayer(damage);
        }
        else if(collision.gameObject.tag == "KillBox")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float yPosition = transform.position.y - speed * Time.deltaTime;
        Vector3 newPosition = new Vector3(transform.position.x, yPosition, transform.position.z);
        transform.position = newPosition;

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.World);
    }
}
