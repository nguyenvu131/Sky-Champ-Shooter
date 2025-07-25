using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level8 : MonoBehaviour {

	public GameObject bomberDronePrefab;
    public int count = 3;
    public float spawnInterval = 1.5f;
    public float spawnX = 10f;
    public float[] yPositions = { 2f, 0f, -2f }; // Vị trí bay khác nhau

    void Start()
    {
        StartCoroutine(SpawnBombers());
    }

    IEnumerator SpawnBombers()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = new Vector3(spawnX, yPositions[i % yPositions.Length], 0);
            Instantiate(bomberDronePrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
