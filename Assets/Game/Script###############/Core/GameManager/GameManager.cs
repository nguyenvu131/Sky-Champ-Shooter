using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement; // Dùng để load scene

public enum GameState
{
    Ready,
    Playing,
    WaveCompleted,
    Victory,
    Defeat,
    Paused
}

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[Header("References")]
	public WaveManagerMonster waveManager;

	[Header("Game State")]
	public GameState currentState = GameState.Ready;

	[Header("Map Settings")]
	public string nextSceneName = "";   // Nếu muốn load theo tên map
	public int nextSceneIndex = -1; 

	void Awake()
	{
		if (Instance == null) Instance = this;
		else Destroy(gameObject);
	}

	void Start()
	{
		RegisterWaveEvents();

		if (waveManager != null && waveManager.autoStart)
		{
			SetGameState(GameState.Playing);
		}
	}

	void RegisterWaveEvents()
	{
		WaveManagerMonster.OnWaveStarted += OnWaveStarted;
		WaveManagerMonster.OnWaveCompleted += OnWaveCompleted;
	}

	void OnDestroy()
	{
		WaveManagerMonster.OnWaveStarted -= OnWaveStarted;
		WaveManagerMonster.OnWaveCompleted -= OnWaveCompleted;
	}

	// ===== GAME STATE HANDLING =====
	public void SetGameState(GameState newState)
	{
		currentState = newState;

		switch (newState)
		{
			case GameState.Ready:
				Debug.Log("[Game] Ready.");
				break;
			case GameState.Playing:
				Debug.Log("[Game] Playing.");
				break;
			case GameState.WaveCompleted:
				Debug.Log("[Game] Wave Completed.");
				break;
			case GameState.Victory:
				Debug.Log("[Game] Victory!");
				LoadNextMap();
				break;
			case GameState.Defeat:
				Debug.Log("[Game] Defeated!");
				break;
			case GameState.Paused:
				Debug.Log("[Game] Paused.");
				break;
		}
	}

	// ===== WAVE CALLBACKS =====
	void OnWaveStarted(string waveName)
	{
		Debug.Log("[GameManager] Wave Started: " + waveName);
		SetGameState(GameState.Playing);
	}

	void OnWaveCompleted(string waveName)
	{
		Debug.Log("[GameManager] Wave Completed: " + waveName);
		SetGameState(GameState.WaveCompleted);

		// Kiểm tra nếu là wave cuối cùng
		if (waveManager != null && waveManager.currentWaveIndex >= waveManager.waves.Count - 1 && !waveManager.loopWaves)
		{
			SetGameState(GameState.Victory);
			ShowVictoryUI();
		}
	}

	public void OnBossDefeated(string waveName)
	{
		Debug.Log("[GameManager] Boss defeated for wave: " + waveName);

		// Gọi hoàn thành màn nếu cần
		WaveManagerMonster waveManager = FindObjectOfType(typeof(WaveManagerMonster)) as WaveManagerMonster;
		if (waveManager != null)
		{
			//waveManager.CompleteCurrentWave();
		}

		// Hiển thị UI thắng, gọi chiến thắng nếu là boss cuối
		if (UIManager.Instance != null)
		{
			//UIManager.Instance.ShowVictory();
		}
	}

	// ===== DEFEAT =====
	public void OnPlayerDead()
	{
		SetGameState(GameState.Defeat);
		ShowDefeatUI();
	}

	// ===== UI PLACEHOLDER =====
	void ShowVictoryUI()
	{
		Debug.Log("[UI] Victory UI shown");
		// TODO: Gọi UIManager.Instance.ShowVictoryPopup();
	}

	void ShowDefeatUI()
	{
		Debug.Log("[UI] Defeat UI shown");
		// TODO: Gọi UIManager.Instance.ShowDefeatPopup();
	}
	
	// ===== CHUYỂN MAP =====
    void LoadNextMap()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("[GameManager] Loading next scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
        else if (nextSceneIndex >= 0)
        {
            Debug.Log("[GameManager] Loading next scene index: " + nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("[GameManager] No next scene set!");
        }
    }
	
	// ===== DEBUG KEYS =====
	void Update()
	{
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.V))
            SetGameState(GameState.Victory);
        if (Input.GetKeyDown(KeyCode.L))
            OnPlayerDead();
        if (Input.GetKeyDown(KeyCode.N))
            waveManager.NextWave();
#endif
	}
}
