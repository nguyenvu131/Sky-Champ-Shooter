using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level34 : MonoBehaviour {

	public GameObject meteorPrefab;
    public Transform spawnRoot;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnMeteorCrash());
    }

    IEnumerator SpawnMeteorCrash()
    {
        int waveCount = 20;
        float delay = 0.3f;

        for (int i = 0; i < waveCount; i++)
        {
            SpawnMeteor(Random.Range(-2f, 2f), Random.Range(5.5f, 7.5f));
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnMeteor(float x, float y)
    {
        Vector3 spawnPos = new Vector3(x, y, 0);
        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity, spawnRoot);

        MeteorCrashMove move = meteor.AddComponent<MeteorCrashMove>();
        move.fallSpeed = Random.Range(5f, 8f);
        move.hasExplosion = (Random.value > 0.7f); // 30% có vụ nổ khi rơi

        spawnedEnemies.Add(meteor);
    }
}
