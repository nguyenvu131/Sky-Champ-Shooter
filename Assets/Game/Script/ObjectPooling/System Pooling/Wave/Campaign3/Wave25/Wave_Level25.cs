using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level25 : MonoBehaviour {

	public GameObject enemyPrefab; // Prefab của quái SideShooter
    public int enemyCount = 10;
    public float spawnInterval = 0.8f;

    private float spawnYTop = 6f;
    private float spawnYBottom = -6f;
    private float spawnXLeft = -10f;
    private float spawnXRight = 10f;

    void Start()
    {
        StartCoroutine(SpawnSideAmbushWave());
    }

    IEnumerator SpawnSideAmbushWave()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Spawn bên trái
            Vector3 leftPos = new Vector3(spawnXLeft, Random.Range(spawnYBottom, spawnYTop), 0);
            GameObject enemyL = Instantiate(enemyPrefab, leftPos, Quaternion.identity);
            enemyL.GetComponent<EnemyMovement25>().InitDirection(Vector3.right + Vector3.down);

            // Spawn bên phải
            Vector3 rightPos = new Vector3(spawnXRight, Random.Range(spawnYBottom, spawnYTop), 0);
            GameObject enemyR = Instantiate(enemyPrefab, rightPos, Quaternion.identity);
            enemyR.GetComponent<EnemyMovement25>().InitDirection(Vector3.left + Vector3.down);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
