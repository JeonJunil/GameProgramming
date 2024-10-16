using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    private bool allWavesCompleted = false;

    public void RegisterEnemy()
    {
        enemyCount++;
    }

    public void EnemyDestroyed()
    {
        enemyCount--;
        if (allWavesCompleted && enemyCount <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    public void AllWavesCompleted()
    {
        allWavesCompleted = true;
        if (enemyCount <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
