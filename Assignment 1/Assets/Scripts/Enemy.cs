using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float knockbackForce;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.EnemyDestroyed();
        }
    }
}
