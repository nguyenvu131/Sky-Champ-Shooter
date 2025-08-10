using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level40 : MonoBehaviour {

	public Transform spawnRoot;
    public GameObject bossPrefab;

    private GameObject boss;

    void Start()
    {
        SpawnBoss();
    }

    void SpawnBoss()
    {
        Vector3 spawnPos = new Vector3(0f, 5.5f, 0f);
        boss = Instantiate(bossPrefab, spawnPos, Quaternion.identity, spawnRoot);
        boss.AddComponent<BossQuantumCore>();
    }
}
