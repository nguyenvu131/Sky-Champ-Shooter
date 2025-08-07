using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level26 : MonoBehaviour {

	public GameObject sniperPrefab;
    public int numberOfEnemies = 5;
    public float spacingX = 2f;
    public float startY = 5.5f;

    void Start()
    {
        SpawnSniperLine();
    }

    void SpawnSniperLine()
    {
        float startX = -((numberOfEnemies - 1) * spacingX) / 2f;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPos = new Vector3(startX + i * spacingX, startY, 0);
            Instantiate(sniperPrefab, spawnPos, Quaternion.identity);
        }
    }
}
