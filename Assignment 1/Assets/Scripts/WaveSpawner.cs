using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    private int enemiesToSpawn;
    private int spawnedEnemies;

    void Start()
    {
        enemiesToSpawn = Mathf.FloorToInt((endTime - startTime) / spawnRate);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndWave", endTime);
    }

    void Spawn()
    {
        if (spawnedEnemies < enemiesToSpawn)
        {
            Vector3 randomPosition = new Vector3(
                transform.position.x + Random.Range(-10f, 10f),
                transform.position.y,
                transform.position.z + Random.Range(-10f, 10f)
            );

            GameObject enemyInstance = Instantiate(prefab, randomPosition, transform.rotation);
            enemyInstance.tag = "Enemy";

            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.RegisterEnemy();
            }

            spawnedEnemies++;
        }
    }

    void EndWave()
    {
        CancelInvoke("Spawn");
        GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.AllWavesCompleted();
        }
    }
}
