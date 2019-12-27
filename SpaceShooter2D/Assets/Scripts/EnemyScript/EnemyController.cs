using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //This script will have all te variables shared among enemies, like HP, damage and score points
    [Header ("Combat vars")]
    [Space(10)]

    public int hp = 5;
    public GameObject ExplosionPrefab;
    public float speed = 3.0f;
    public float shotCD = 5.0f;
    public float blinkTime = 1.0f;
    public int damage = 1;
    public int score = 100;
    public AudioClip shotSound;

    [Header("Spawnable PowerUps")]
    [Space(10)]

    public GameObject shield;
    public GameObject shot;
    public GameObject heal;
    public float probability = 0.0f;

    private Color mainColor;
    private SpriteRenderer sRenderer;
    private AudioSource audioSource;
    private ResourceManager resManager;
    private CombatController combat;
    private float blinkTimer = 0.0f;
    private bool damaged = false;

    public void PlayShotAudio()
    {
        audioSource.PlayOneShot(shotSound);
    }

    //Will damage the enemy
    public void Damage(int amount)
    {
        hp -= amount;
        damaged = true;

        if (hp <= 0)
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

            SpawnPowerUp();

            Destroy(gameObject);
        }
    }

    //Upon death thhis function will be called to (maybe) spawn a powerup
    private void SpawnPowerUp()
    {
        float rand = Random.Range(0.0f, 1.0f);

        if (rand < probability)
        {
            int type = Random.Range(0, 3);

            switch (type)
            {
                case 0:
                    Instantiate(shield, gameObject.transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(shot, gameObject.transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(heal, gameObject.transform.position, Quaternion.identity);
                    break;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //If both ships collide they both take damage
            Damage(1);
            collision.gameObject.GetComponent<PlayerScript>().DamagePlayer(1);
        }
        else if(collision.gameObject.tag == "Obstacle")
        {
            //destroy instantly
            Damage(10);
        }
    }

    private void Start()
    {
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        combat = GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatController>();
        sRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        mainColor = sRenderer.color;
        combat.AddEnemy();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(damaged)
        {
            sRenderer.color = Color.red;
            
            if(blinkTimer > blinkTime)
            {
                blinkTimer = 0.0f;
                sRenderer.color = mainColor;
                damaged = false;
            }
            else
            {
                blinkTimer += Time.deltaTime;
            }

        }
    }

    private void OnDestroy()
    {
        combat.EraseEnemy();
        resManager.AddToScore(score);
    }
}
