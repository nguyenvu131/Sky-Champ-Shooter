using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Waiting,        // Đợi người chơi bắt đầu
    Starting,       // Đang đếm ngược bắt đầu
    Playing,        // Đang chơi
    Paused,         // Đã tạm dừng
    Win,            // Thắng
    Lose,           // Thua
    Cutscene,       // Đang xem cắt cảnh
    Dialog,         // Đang đối thoại
    Transitioning,  // Đang chuyển cảnh hoặc chuyển map
    GameOver        // Kết thúc hoàn toàn game
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("LEVEL")]
    public int currentLevel = 1;
    public int maxLevel = 10;

    [Header("References")]
    public MapManager mapManager;
    public WaveManager waveManager;
    public UIManager uiManager;
    public GameObject player;
	public Text countdownText;

    private GameState currentState = GameState.Waiting;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        InitLevel();
    }

    void InitLevel()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        if (currentLevel > maxLevel) currentLevel = maxLevel;

        mapManager.LoadMap(currentLevel);
        waveManager.LoadWavesForLevel(currentLevel);

        player.transform.position = Vector3.zero;

        currentState = GameState.Waiting;
        if (uiManager != null) uiManager.ShowStartMessage();
    }

    public void StartGame()
    {
        if (currentState != GameState.Waiting) return;

        currentState = GameState.Starting;
        StartCoroutine(DelayedStartGame());
    }

    IEnumerator DelayedStartGame()
    {
		int countdown = 3;
		if (countdownText != null)
			countdownText.gameObject.SetActive(true);

		while (countdown > 0)
		{
			if (countdownText != null)
				countdownText.text = countdown.ToString();

			yield return new WaitForSeconds(1f);
			countdown--;
		}

		if (countdownText != null)
		{
			countdownText.text = "GO!";
			yield return new WaitForSeconds(0.5f);
			countdownText.gameObject.SetActive(false);
		}
        // if (uiManager != null) 
			// uiManager.ShowCountdown(3);
        // yield return new WaitForSeconds(3f);

        currentState = GameState.Playing;
        waveManager.StartWave();
        uiManager.HideStartMessage();
    }

    public void PauseGame()
    {
        if (currentState != GameState.Playing) return;

        currentState = GameState.Paused;
        Time.timeScale = 0f;
        // uiManager.ShowPauseMenu();
    }

    public void ResumeGame()
    {
        if (currentState != GameState.Paused) return;

        currentState = GameState.Playing;
        Time.timeScale = 1f;
        // uiManager.HidePauseMenu();
    }

    public void EnterCutscene()
    {
        currentState = GameState.Cutscene;
        Time.timeScale = 0;
    }

    public void EnterDialog()
    {
        currentState = GameState.Dialog;
        Time.timeScale = 0;
    }

    public void ExitDialog()
    {
        currentState = GameState.Playing;
        Time.timeScale = 1;
    }

    public void OnEnemyDefeated()
    {
        if (waveManager.AllWavesCompleted() && waveManager.AllEnemiesDefeated())
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        if (currentState != GameState.Playing) return;

        currentState = GameState.Win;
        uiManager.ShowWinMessage();

        if (currentLevel < maxLevel)
        {
            PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
        }

        Time.timeScale = 0;
    }

    public void LoseGame()
    {
        if (currentState != GameState.Playing) return;

        currentState = GameState.Lose;
        uiManager.ShowLoseMessage();
        Time.timeScale = 0;
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        // Application.LoadLevel("Mapgame");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        // Application.LoadLevel("MainMenu");
    }

    public bool IsPlaying()
    {
        return currentState == GameState.Playing;
    }

    public bool IsPaused()
    {
        return currentState == GameState.Paused;
    }

    public bool IsInDialogOrCutscene()
    {
        return currentState == GameState.Dialog || currentState == GameState.Cutscene;
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }
	
	public void OnLevelCompleted()
	{
		Debug.Log("Người chơi đã hoàn thành cấp độ!");
		WinLoseManager.Instance.WinGame();
	}
	
	
}
