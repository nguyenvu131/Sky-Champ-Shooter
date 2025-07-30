using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public static UIManager Instance;

    [Header("UI References")]
    public Text levelText;
    public Text waveText;
    public GameObject startPanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject inGameHUD;
	public GameObject pausePanel; // ➤ Thêm mới
	
	public GameObject bossWarningUI;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpdateLevelText(int level)
    {
        if (levelText != null)
            levelText.text = "Level " + level;
    }

    public void UpdateWaveText(int wave, int total)
    {
        if (waveText != null)
            waveText.text = "Wave " + wave + " / " + total;
    }

    public void ShowStartMessage()
    {
        startPanel.SetActive(true);
        inGameHUD.SetActive(false);
    }

    public void HideStartMessage()
    {
        startPanel.SetActive(false);
        inGameHUD.SetActive(true);
    }

    public void ShowWinMessage()
    {
        winPanel.SetActive(true);
        inGameHUD.SetActive(false);
    }

    public void ShowLoseMessage()
    {
        losePanel.SetActive(true);
        inGameHUD.SetActive(false);
    }

    public void OnClickStartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void OnClickRetry()
    {
        GameManager.Instance.RetryLevel();
    }

    public void OnClickMainMenu()
    {
        GameManager.Instance.GoToMainMenu();
    }
	
	public void ShowBossWarning()
	{
		bossWarningUI.SetActive(true);
		Invoke("HideBossWarning", 2f);
	}

	void HideBossWarning()
	{
		bossWarningUI.SetActive(false);
	}
	
	public void OnClickPause()
	{
		Time.timeScale = 0f; // Dừng game
		pausePanel.SetActive(true);
		inGameHUD.SetActive(false);
	}

	public void OnClickResume()
	{
		Time.timeScale = 1f; // Tiếp tục game
		pausePanel.SetActive(false);
		inGameHUD.SetActive(true);
	}
	
	
}
