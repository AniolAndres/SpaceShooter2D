using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("Enemy Ships")]
    [Space(10)]

    public GameObject firstSpawn;
    public GameObject secondSpawn;
    public GameObject thirdSpawn;
    public GameObject basicEnemyPrefab;
    public GameObject mediumEnemyPrefab;
    public GameObject eliteEnemyPrefab;
    public float deviation = 0.0f;


    private int lastSpawn = 0;
    private int secondLastSpawn = 0;

    [Header("Obstacles")]
    [Space(10)]

    public GameObject obsSpawn;
    public GameObject obstaclePrefab;
    public float width;

    [Header("Stars")]
    [Space(10)]
    public GameObject starPrefab;
    public float starInterval = 6.0f;

    private float currentStarInterval = 6.0f;
    private float starTimer = 0.0f;

    public void SpawnObstacle()
    {
        float randX = Random.Range(-width, width);
        Vector3 totalDeviation = new Vector3(randX, 0.0f, 0.0f);
        Instantiate(obstaclePrefab, obsSpawn.transform.position + totalDeviation, Quaternion.identity);
    }

    private GameObject SelectEnemy(int difficulty)
    {
        GameObject result;

        if(difficulty < 2)
        {
            result = basicEnemyPrefab;
        }
        else if(difficulty < 4)
        {
            result = mediumEnemyPrefab;
        }
        else
        {
            result = eliteEnemyPrefab;
        }

        return result;
    }

    public void SpawnStar()
    {
        float randX = Random.Range(-width, width);
        Vector3 totalDeviation = new Vector3(randX, 0.0f, 0.0f);
        Instantiate(starPrefab, obsSpawn.transform.position + totalDeviation, Quaternion.identity);
    }

    public void SpawnEnemy(int difficulty)
    {
        int actualSpawn = 1;

        float randX = Random.Range(-deviation, deviation);
        float randY = Random.Range(-deviation, deviation);
        Vector3 totalDeviation = new Vector3(randX, randY, 0.0f);

        while (actualSpawn == lastSpawn || actualSpawn == secondLastSpawn)
        {
            ++actualSpawn;
        }

        GameObject newPrefab = SelectEnemy(difficulty);

        switch (actualSpawn)
        {
            case 1:
                Instantiate(newPrefab, firstSpawn.transform.position + totalDeviation, Quaternion.identity);
                break;
            case 2:
                Instantiate(newPrefab, secondSpawn.transform.position + totalDeviation, Quaternion.identity);
                break;
            case 3:
                Instantiate(newPrefab, thirdSpawn.transform.position + totalDeviation, Quaternion.identity);
                break;
        }

        secondLastSpawn = lastSpawn;
        lastSpawn = actualSpawn;
    }

    private float GenerateRandStarInterval()
    {
        return Random.Range(starInterval * 0.8f, starInterval * 1.2f);
    }

    private void Update()
    {
        if(starTimer > currentStarInterval)
        {
            currentStarInterval = GenerateRandStarInterval();
            SpawnStar();
            starTimer = 0.0f;
        }
        else
        {
            starTimer += Time.deltaTime;
        }
    }

    private void Start()
    {
        float rand = Random.Range(starInterval * 0.8f, starInterval * 1.2f);
        currentStarInterval = rand;
    }
}
