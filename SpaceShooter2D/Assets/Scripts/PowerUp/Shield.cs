using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 direction = new Vector3(0, 1, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerScript pScript = collision.gameObject.GetComponent<PlayerScript>();

            pScript.ShieldPlayer();

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "KillBox")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = transform.position - direction * speed * Time.deltaTime;
    }
}
