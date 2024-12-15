using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false; // 게임 상태를 확인하는 변수
    public GameObject pauseMenuUI;       // Pause Menu의 UI 패널

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // UI 비활성화
        Time.timeScale = 1f;          // 게임 재개
        isPaused = false;             // 상태 업데이트
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // UI 활성화
        Time.timeScale = 0f;         // 게임 일시정지
        isPaused = true;             // 상태 업데이트
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();          // 게임 종료
    }
}
