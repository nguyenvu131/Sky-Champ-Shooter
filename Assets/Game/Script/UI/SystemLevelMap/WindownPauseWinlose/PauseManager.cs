using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	public static PauseManager Instance;

    private bool isPaused = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        if (isPaused) return;

        isPaused = true;
        Time.timeScale = 0f;

        // Gọi UIManager để hiển thị pausePanel
        if (UIManager.Instance != null)
        {
            UIManager.Instance.pausePanel.SetActive(true);
            UIManager.Instance.inGameHUD.SetActive(false);
        }

        Debug.Log("Game PAUSED");
    }

    public void ResumeGame()
    {
        if (!isPaused) return;

        isPaused = false;
        Time.timeScale = 1f;

        // Gọi UIManager để ẩn pausePanel
        if (UIManager.Instance != null)
        {
            UIManager.Instance.pausePanel.SetActive(false);
            UIManager.Instance.inGameHUD.SetActive(true);
        }

        Debug.Log("Game RESUMED");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
