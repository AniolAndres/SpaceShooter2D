using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public int scoreThreshold;
    public float spawnInterval;
    public float obstacleInterval;
    public int difficultyLevel = 0;

    private SpawnController spawnC;
    private ResourceManager resManager;
    private int actualTreshold = 0;
    private int enemiesInScreen = 0;
    private int totalEnemiesPosible = 3;
    private int score = 0;
    private float spawnTimer = 0.0f;
    private float obstacleTimer = 0.0f;
    private bool halfEnemy = false;

    public void AddEnemy()
    {
        enemiesInScreen += 1;
    }

    public void EraseEnemy()
    {
        enemiesInScreen -= 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnC = GameObject.FindGameObjectWithTag("SpawnController").GetComponent<SpawnController>();
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        actualTreshold += scoreThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        score = resManager.GetScore();

        if(spawnTimer > spawnInterval && enemiesInScreen < totalEnemiesPosible)
        {
            spawnC.SpawnEnemy(difficultyLevel);
            spawnTimer = 0.0f;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }

        if(obstacleTimer > obstacleInterval)
        {
            spawnC.SpawnObstacle();
            obstacleTimer = 0.0f;
        }
        else
        {
            obstacleTimer += Time.deltaTime;
        }

        //tihs will make the game increasingly harder
        if(score > actualTreshold)
        {
            spawnInterval *= 0.9f;
            
            //Increments one every 2 difficulty levels
            if(!halfEnemy)
            {
                halfEnemy = true;
            }
            else
            {
                ++totalEnemiesPosible;
                halfEnemy = false;
            }

            ++difficultyLevel;
            scoreThreshold += scoreThreshold / 5;
            actualTreshold += scoreThreshold;
        }
    }
}
