using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level28 : MonoBehaviour {

	public GameObject portalPrefab;
    public int portalCount = 3;
    public float spawnInterval = 4f;
    public Vector2 spawnRangeX = new Vector2(-6f, 6f);
    public Vector2 spawnRangeY = new Vector2(-4f, 4f);

    void Start()
    {
        StartCoroutine(SpawnPortals());
    }

    IEnumerator SpawnPortals()
    {
        for (int i = 0; i < portalCount; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(spawnRangeX.x, spawnRangeX.y),
                Random.Range(spawnRangeY.x, spawnRangeY.y),
                0
            );

            Instantiate(portalPrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
