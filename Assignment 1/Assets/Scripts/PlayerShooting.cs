using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
 {
    public GameObject prefab;
    public GameObject shootPoint;
    public float tripleShootInterval = 3.0f;
    public float spreadAngle = 30f;

    private float tripleShootTimer;

    private void Update()
    {
        tripleShootTimer += Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBasicBullet();
        }

        // 3초마다 퍼지는 빠른 총알 발사
        if (tripleShootTimer >= tripleShootInterval)
        {
            StartCoroutine(FireSpreadBullets());
            tripleShootTimer = 0f;
        }
    }

    void FireBasicBullet()
    {
        
        GameObject bullet = Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);
    }

    IEnumerator FireSpreadBullets()
    {
        FireFastBullet(shootPoint.transform.rotation);

        Quaternion leftRotation = Quaternion.Euler(0, -spreadAngle, 0) * shootPoint.transform.rotation;
        FireFastBullet(leftRotation);

        Quaternion rightRotation = Quaternion.Euler(0, spreadAngle, 0) * shootPoint.transform.rotation;
        FireFastBullet(rightRotation);

        yield return null;
    }

    void FireFastBullet(Quaternion rotation)
    {
        GameObject bullet = Instantiate(prefab, shootPoint.transform.position, rotation);
        bullet.GetComponent<ForwardMovement>().speed = 40f;
    }
}