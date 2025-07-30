using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    public static WinLoseManager Instance;

    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Gọi khi người chơi thắng
    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        Time.timeScale = 0f;

        if (UIManager.Instance != null)
            UIManager.Instance.ShowWinMessage();

        Debug.Log("YOU WIN!");
    }

    // Gọi khi người chơi thua
    public void LoseGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        Time.timeScale = 0f;

        if (UIManager.Instance != null)
            UIManager.Instance.ShowLoseMessage();

        Debug.Log("YOU LOSE!");
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Đảm bảo scene này tồn tại
    }
}
