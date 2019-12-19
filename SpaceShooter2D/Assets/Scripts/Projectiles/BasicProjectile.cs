using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    private float speed = 1.0f;
    private float damage = 1.0f;
    Vector3 direction = new Vector3(0.0f, 1.0f, 0.0f);

    public void SetSpeed(float s) { speed = s; }
    public void SetDamage(float d) { damage = d; }
    public float GetDamage() { return damage; }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "ProjectileKillBox" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
