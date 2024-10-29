using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    public float knockbackForce;
    public ParticleSystem boneExplosion;  // 파티클 시스템 추가
    public VisualEffect soulEffect;       // Visual Effect 추가

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Visual Effect 실행 (적 생성 시)
        if (soulEffect != null)
        {
            soulEffect.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 knockbackDirection = (transform.position - contact.point).normalized;
            knockbackDirection.y = 0;

            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }

    void OnDestroy()
    {
        // Bone Explosion 파티클 효과 실행 (적 파괴 시)
        if (boneExplosion != null)
        {
            ParticleSystem explosion = Instantiate(boneExplosion, transform.position, Quaternion.identity);
            explosion.Play();
            Destroy(explosion.gameObject, explosion.main.duration + explosion.main.startLifetime.constant);  // 파티클이 실행된 후 일정 시간 후 파괴
        }

        // GameManager에 적 파괴 알림
        GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.EnemyDestroyed();
        }
    }
}