using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMonster : MonoBehaviour {

	public static GameManagerMonster Instance;
	public GameObject gameOverUI;

	public GameObject revivePanel;
	public GameObject gameOverPanel;

	public bool hasRevived = false;
	public float reviveCountdown = 5f;

	public void OnPlayerDie()
	{
		// Hiện Game Over UI
		if (gameOverUI)
			gameOverUI.SetActive(true);

		// Tạm dừng game
		Time.timeScale = 0f;

	}

	public void RestartGame()
	{
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}


}
