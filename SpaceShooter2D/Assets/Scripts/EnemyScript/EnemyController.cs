using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //This script will have all te variables shared among enemies, like HP, damage and score points

    public float hp = 5.0f;
    public GameObject ExplosionPrefab;

    public void Damage(float amount)
    {
        hp -= amount;
        if(hp <= 0.0f)
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerProjectile")
        {
            Damage(collision.gameObject.GetComponent<BasicProjectile>().GetDamage());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
