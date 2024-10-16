using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
