using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float changeDirectionInterval = 2.0f;

    private float directionChangeTimer;
    private Vector3 movementDirection;

    void Start()
    {
        SetRandomDirection();
    }

    void Update()
    {
        directionChangeTimer += Time.deltaTime;

        if (directionChangeTimer >= changeDirectionInterval)
        {
            SetRandomDirection();
            directionChangeTimer = 0f; 
        }

        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    void SetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        movementDirection = new Vector3(randomX, 0, randomZ).normalized;
    }
}
