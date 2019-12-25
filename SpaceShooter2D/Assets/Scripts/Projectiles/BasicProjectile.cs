using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    //I can use this script for every projectile that travels in a straight line for now, just changing speed to a negative value

    private float speed = 1.0f;
    private int damage = 1;
    private SpriteRenderer mySprite;
    private Vector3 direction = new Vector3(0.0f, 1.0f, 0.0f);

    public void SetSpeed(float s) { speed = s; }
    public void SetDamage(int d) { damage = d; }
    public int GetDamage() { return damage; }
    public void SetTag(string newTag) { gameObject.tag = newTag; } 

    private void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(gameObject.tag == "PlayerProjectile")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyController>().Damage(damage);
                Destroy(gameObject);
            }
        }
        else if(gameObject.tag == "EnemyProjectile")
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerScript pScript = collision.gameObject.GetComponent<PlayerScript>();
                if(!pScript.IsInvul())
                {
                    pScript.DamagePlayer(damage);
                    Destroy(gameObject);
                }
            }
        }

        if (collision.gameObject.tag == "KillBox")
        {
            Destroy(gameObject);
        }

    }
}
