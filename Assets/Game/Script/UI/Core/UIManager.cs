using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable()
	{
		BossHealth.onBossDead += OnMiniBossDefeated;
	}

	void OnDisable()
	{
		BossHealth.onBossDead -= OnMiniBossDefeated;
	}

	void OnMiniBossDefeated()
	{
//		ShowMessage("MiniBoss defeated!");
//		SpawnNextWave();
	}
}
