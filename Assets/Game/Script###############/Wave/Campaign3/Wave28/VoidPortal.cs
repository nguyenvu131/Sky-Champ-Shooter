using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPortal : MonoBehaviour {

	public GameObject enemyPrefab;
    public int enemiesToSpawn = 5;
    public float spawnDelay = 0.6f;
    public float portalDuration = 4f;
    public GameObject spawnEffect;
	public GameObject enemy;

    private float lifeTimer;

    void Start()
    {
        lifeTimer = portalDuration;
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            if (spawnEffect)
                Instantiate(spawnEffect, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
