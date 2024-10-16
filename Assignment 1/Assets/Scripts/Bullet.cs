using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  // 적 파괴
            Destroy(gameObject);  // 총알 파괴
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
