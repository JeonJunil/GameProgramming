using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    void Spawn()
    {
        Vector3 randomPosition = new Vector3(
            transform.position.x + Random.Range(-10f, 10f),
            transform.position.y,
            transform.position.z + Random.Range(-10f, 10f)
        );

        Instantiate(prefab, randomPosition, transform.rotation);
    }
}
