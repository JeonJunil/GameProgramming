using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
