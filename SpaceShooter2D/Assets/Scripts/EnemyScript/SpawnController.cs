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
    public GameObject enemyPrefab;
    public float deviation = 0.0f;

    [Header("Obstacles")]
    [Space(10)]

    public GameObject obsSpawn;
    public GameObject obstaclePrefab;
    public float width;

    private int lastSpawn = 0;
    private int secondLastSpawn = 0;

    public void SpawnObstacle()
    {
        float randX = Random.Range(-width, width);
        Vector3 totalDeviation = new Vector3(randX, 0.0f, 0.0f);
        Instantiate(obstaclePrefab, obsSpawn.transform.position + totalDeviation, Quaternion.identity);
    }

    public void SpawnEnemy()
    {
        int actualSpawn = 1;

        float randX = Random.Range(-deviation, deviation);
        float randY = Random.Range(-deviation, deviation);
        Vector3 totalDeviation = new Vector3(randX, randY, 0.0f);

        while (actualSpawn == lastSpawn || actualSpawn == secondLastSpawn)
        {
            ++actualSpawn;
        }

        switch (actualSpawn)
        {
            case 1:
                Instantiate(enemyPrefab, firstSpawn.transform.position + totalDeviation, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyPrefab, secondSpawn.transform.position + totalDeviation, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemyPrefab, thirdSpawn.transform.position + totalDeviation, Quaternion.identity);
                break;
        }

        secondLastSpawn = lastSpawn;
        lastSpawn = actualSpawn;
    }
}
