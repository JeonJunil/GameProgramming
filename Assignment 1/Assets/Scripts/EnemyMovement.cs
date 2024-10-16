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
        // X는 좌우로 랜덤, Z는 항상 양수 (앞으로만 이동)
        float randomX = Random.Range(-1f, 1f);
        float fixedZ = 1f;  // 앞으로 이동하는 값 (Z축)

        // Y축은 0으로 유지하고, Z축은 앞으로 이동
        movementDirection = new Vector3(randomX, 0, fixedZ).normalized;
    }
}
