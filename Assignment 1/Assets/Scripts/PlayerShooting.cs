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

        if (tripleShootTimer >= tripleShootInterval)
        {
            StartCoroutine(FireSpreadBullets());
            tripleShootTimer = 0f;
        }
    }

    void FireBasicBullet()
    {
        GameObject bullet = Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false; // Rigidbody가 물리적 상호작용을 할 수 있도록 설정
            rb.useGravity = false;  // 총알이 중력의 영향을 받지 않도록 설정
            rb.velocity = shootPoint.transform.forward * 20f; // 총알 발사 속도 설정
        }

        bullet.layer = LayerMask.NameToLayer("Bullet");
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
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false; // Rigidbody가 물리적 상호작용을 할 수 있도록 설정
            rb.useGravity = false;  // 총알이 중력의 영향을 받지 않도록 설정
            rb.velocity = shootPoint.transform.forward * 40f; // 더 빠른 총알 발사 속도 설정
        }

        bullet.layer = LayerMask.NameToLayer("Bullet");
    }
}