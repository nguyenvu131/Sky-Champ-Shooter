using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleUIManager : MonoBehaviour {

	public static BattleUIManager Instance;

	[Header("UI Panels")]
	public GameObject startPanel;
	public GameObject inGameHUD;
	public GameObject pausePanel;
	public GameObject winPanel;
	public GameObject losePanel;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		ShowStartPanel();
	}

	// ========== UI FLOW ==========
	public void ShowStartPanel()
	{
		startPanel.SetActive(true);
		inGameHUD.SetActive(false);
		pausePanel.SetActive(false);
		winPanel.SetActive(false);
		losePanel.SetActive(false);
		Time.timeScale = 0f;
	}

	public void StartBattle()
	{
		startPanel.SetActive(false);
		inGameHUD.SetActive(true);
		Time.timeScale = 1f;
	}

	public void PauseBattle()
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void ResumeBattle()
	{
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void EndBattleWin()
	{
		winPanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void EndBattleLose()
	{
		losePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void QuitToMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	public void RetryBattle()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
