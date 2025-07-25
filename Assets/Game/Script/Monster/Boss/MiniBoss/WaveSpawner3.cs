using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner3 : MonoBehaviour {

	public GameObject miniBossPrefab;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnWave(int waveNumber)
	{
		if (waveNumber == 5)
		{
			Instantiate(miniBossPrefab, spawnPoint.position, Quaternion.identity);
		}
		else
		{
			// Spawn enemies thường
		}
	}
}
