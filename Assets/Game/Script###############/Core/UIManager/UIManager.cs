using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Text Elements")]
    public Text waveNameText;
    public Text gameStateText;

    [Header("Panels / Popups")]
    public GameObject victoryPanel;
    public GameObject defeatPanel;
    public GameObject pausePanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        RegisterEvents();

        HideAllPopups();
        UpdateGameStateText(GameManager.Instance.currentState);
    }

    void RegisterEvents()
    {
        WaveManagerMonster.OnWaveStarted += OnWaveStarted;
        WaveManagerMonster.OnWaveCompleted += OnWaveCompleted;
    }

    void OnDestroy()
    {
        WaveManagerMonster.OnWaveStarted -= OnWaveStarted;
        WaveManagerMonster.OnWaveCompleted -= OnWaveCompleted;
    }

    void OnWaveStarted(string waveName)
    {
        if (waveNameText != null)
            waveNameText.text = "Wave: " + waveName;

        HideAllPopups();
        UpdateGameStateText(GameState.Playing);
    }

    void OnWaveCompleted(string waveName)
    {
        UpdateGameStateText(GameState.WaveCompleted);
    }

    public void UpdateGameStateText(GameState state)
    {
        if (gameStateText != null)
        {
            gameStateText.text = "State: " + state.ToString();
        }

        // Hiển thị UI tương ứng nếu cần
        switch (state)
        {
            case GameState.Victory:
                ShowVictoryPopup();
                break;
            case GameState.Defeat:
                ShowDefeatPopup();
                break;
            case GameState.Paused:
                ShowPausePopup();
                break;
        }
    }

    // ===== POPUP CONTROL =====
    public void ShowVictoryPopup()
    {
        HideAllPopups();
        if (victoryPanel != null)
            victoryPanel.SetActive(true);
    }

    public void ShowDefeatPopup()
    {
        HideAllPopups();
        if (defeatPanel != null)
            defeatPanel.SetActive(true);
    }

    public void ShowPausePopup()
    {
        HideAllPopups();
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void HideAllPopups()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(false);
        if (defeatPanel != null)
            defeatPanel.SetActive(false);
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    // ===== BUTTONS =====
    public void OnClick_NextWave()
    {
        WaveManagerMonster waveMgr = GameObject.FindObjectOfType<WaveManagerMonster>();
        if (waveMgr != null)
            waveMgr.NextWave();
    }

    public void OnClick_RestartWave()
    {
        WaveManagerMonster waveMgr = GameObject.FindObjectOfType<WaveManagerMonster>();
        if (waveMgr != null)
            waveMgr.RestartCurrentWave();
    }

    public void OnClick_Resume()
    {
        GameManager.Instance.SetGameState(GameState.Playing);
        HideAllPopups();
    }

    public void OnClick_Pause()
    {
        GameManager.Instance.SetGameState(GameState.Paused);
        ShowPausePopup();
    }

    // ===== DEBUG KEYS =====
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameManager.Instance.SetGameState(GameState.Victory);
            ShowVictoryPopup();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.SetGameState(GameState.Defeat);
            ShowDefeatPopup();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClick_Pause();
        }
#endif
    }
}
