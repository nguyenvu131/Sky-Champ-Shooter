using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level3 : MonoBehaviour {

	public GameObject explodingBugPrefab;
    public int count = 3;
    public float spawnInterval = 1f;
    public float startX = 10f;
    public float startY = 0f;
    public float ySpacing = -1.5f;

    void Start()
    {
        StartCoroutine(SpawnExplodingBugs());
    }

    IEnumerator SpawnExplodingBugs()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = new Vector3(startX, startY + i * ySpacing, 0);
            Instantiate(explodingBugPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
