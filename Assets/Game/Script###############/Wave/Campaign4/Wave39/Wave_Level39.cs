using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level39 : MonoBehaviour {

	public Transform spawnRoot;
    public GameObject warningLinePrefab;     // Đường cảnh báo tia laser
    public GameObject laserBeamPrefab;       // Tia laser thật sự
    public GameObject enemyPrefab;           // Địch phụ xen kẽ

    private float waveDuration = 20f;
    private float laserDuration = 1.5f;
    private float warningDuration = 1f;

    private float[] laserXPositions = new float[] { -2f, -1f, 0f, 1f, 2f };

    void Start()
    {
        StartCoroutine(SpawnLaserGridPattern());
    }

    IEnumerator SpawnLaserGridPattern()
    {
        float timer = 0f;

        while (timer < waveDuration)
        {
            float delayBetweenLasers = 2.5f;

            // Random chọn 2 vị trí laser bắn
            int laserCount = Random.Range(2, 4);
            int[] indexes = new int[laserCount];
            for (int i = 0; i < laserCount; i++)
                indexes[i] = Random.Range(0, laserXPositions.Length);

            foreach (int index in indexes)
            {
                StartCoroutine(TriggerLaserAtPosition(laserXPositions[index]));
            }

            // Spawn địch xen kẽ
            SpawnPassingEnemy();

            timer += delayBetweenLasers;
            yield return new WaitForSeconds(delayBetweenLasers);
        }
    }

    IEnumerator TriggerLaserAtPosition(float x)
    {
        // Cảnh báo laser trước
        GameObject warning = Instantiate(warningLinePrefab, new Vector3(x, 0f, 0f), Quaternion.identity, spawnRoot);
        yield return new WaitForSeconds(warningDuration);

        Destroy(warning);

        // Bắn laser thật
        GameObject laser = Instantiate(laserBeamPrefab, new Vector3(x, 0f, 0f), Quaternion.identity, spawnRoot);
        yield return new WaitForSeconds(laserDuration);

        Destroy(laser);
    }

    void SpawnPassingEnemy()
    {
        float spawnX = Random.Range(-2.5f, 2.5f);
        Vector3 spawnPos = new Vector3(spawnX, 6f, 0f);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity, spawnRoot);
        enemy.AddComponent<PassingEnemy>().Init(3f);
    }
}
