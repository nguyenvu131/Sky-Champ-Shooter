using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }

	public int playerScore;
	public int currentLevel;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject); // Đảm bảo chỉ có một GameManager
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject); // Không bị huỷ khi đổi scene
	}

	public void GameOver()
	{
		Debug.Log("Game Over!");
		// Xử lý dừng game, hiển thị UI thua
	}
}
