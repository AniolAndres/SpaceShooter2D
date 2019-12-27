using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public float speed = 1.0f;
    public int healAmount = 1;
    private Vector3 direction = new Vector3(0, 1, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerScript pScript = collision.gameObject.GetComponent<PlayerScript>();

            pScript.HealPlayer(healAmount);

            Destroy(gameObject);
        }
    }


    private void Update()
    {
        transform.position = transform.position - direction * speed * Time.deltaTime;
    }
}
