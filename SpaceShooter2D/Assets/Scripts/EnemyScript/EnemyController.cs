using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //This script will have all te variables shared among enemies, like HP, damage and score points

    public int hp = 5;
    public GameObject ExplosionPrefab;
    public float speed = 3.0f;
    public float shotCD = 5.0f;
    public int damage = 1;
    public int score = 100;


    private ResourceManager resManager;

    public void Damage(int amount)
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

    private void Start()
    {
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        resManager.AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        resManager.EraseEnemy();
        resManager.AddToScore(score);
    }
}
