using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level7 : MonoBehaviour {

	public GameObject beePrefab;
    public int beeCount = 6;
    public float spawnInterval = 0.4f;
    public float spawnX = 10f;
    public float spawnY = 0f;

    void Start()
    {
        StartCoroutine(SpawnSpiralBees());
    }

    IEnumerator SpawnSpiralBees()
    {
        for (int i = 0; i < beeCount; i++)
        {
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
            Instantiate(beePrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
