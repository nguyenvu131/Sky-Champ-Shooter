using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level15 : MonoBehaviour {

	public GameObject monsterPrefab;
    public int enemyCount = 6;
    public float spacingX = 2f;
    public Transform spawnCenter;

    void Start()
    {
        SpawnStealthCloakers();
    }

    void SpawnStealthCloakers()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = spawnCenter.position + new Vector3((i - enemyCount / 2) * spacingX, 0, 0);
            Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
        }
    }
}
