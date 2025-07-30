using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level33 : MonoBehaviour {

	public GameObject spiralEnemyPrefab;
    public Transform spawnRoot;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnTwinSpirals());
    }

    IEnumerator SpawnTwinSpirals()
    {
        int spiralCount = 6;
        float delay = 0.7f;

        for (int i = 0; i < spiralCount; i++)
        {
            SpawnSpiralEnemy(isClockwise: true);
            SpawnSpiralEnemy(isClockwise: false);

            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnSpiralEnemy(bool isClockwise)
    {
        Vector3 startPosition = new Vector3(0, 6f, 0);
        GameObject enemy = Instantiate(spiralEnemyPrefab, startPosition, Quaternion.identity, spawnRoot);

        SpiralMove33 spiral = enemy.AddComponent<SpiralMove33>();
        spiral.isClockwise = isClockwise;

        spawnedEnemies.Add(enemy);
    }
}
