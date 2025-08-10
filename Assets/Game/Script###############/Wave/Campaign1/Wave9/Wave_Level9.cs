using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level9 : MonoBehaviour
{
    public GameObject chargerPrefab;  // Prefab Drag từ Inspector
    public int count = 4;
    public float spawnInterval = 1.2f;
    public float spawnX = 10f;
    public float[] yPositions = { 2.5f, 1f, -1f, -2.5f };
	public GameObject charger;

    void Start()
    {
        StartCoroutine(SpawnChargers());
    }

    IEnumerator SpawnChargers()
    {
        for (int i = 0; i < count; i++)
        {
            float y = yPositions[i % yPositions.Length];
            Vector3 spawnPos = new Vector3(spawnX, y, 0);

            charger = Instantiate(chargerPrefab, spawnPos, Quaternion.identity);
            // Không cần SetActive(true), vì object mới sinh ra luôn là active

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
