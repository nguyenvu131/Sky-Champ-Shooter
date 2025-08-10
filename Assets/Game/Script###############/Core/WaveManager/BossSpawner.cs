using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossSpawner : MonoBehaviour
{
    [Header("Boss Settings")]
    public GameObject bossPrefab;       // Prefab Boss
    public Transform spawnPoint;        // Vị trí spawn boss
    public float spawnDelay = 1f;       // Thời gian chờ trước khi spawn

    public Action<GameObject> OnBossSpawned; // Event khi boss spawn

    private GameObject currentBoss;

    /// <summary>
    /// Spawn boss với delay
    /// </summary>
    public void SpawnBoss()
    {
        StartCoroutine(SpawnBossRoutine());
    }

    IEnumerator SpawnBossRoutine()
    {
        yield return new WaitForSeconds(spawnDelay);

        if (bossPrefab != null && spawnPoint != null)
        {
            currentBoss = Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity) as GameObject;

            // Đăng ký boss vào WaveManager
            if (WaveManagerMonster.Instance != null)
            {
                WaveManagerMonster.Instance.RegisterBoss(currentBoss);
            }

            // Gọi event
            if (OnBossSpawned != null)
                OnBossSpawned(currentBoss);

            Debug.Log("[BossSpawner] Boss spawned: " + currentBoss.name);
        }
        else
        {
            Debug.LogWarning("[BossSpawner] Missing bossPrefab or spawnPoint!");
        }
    }

    /// <summary>
    /// Xóa boss hiện tại
    /// </summary>
    public void ClearBoss()
    {
        if (currentBoss != null)
        {
            Destroy(currentBoss);
            currentBoss = null;
        }
    }

    /// <summary>
    /// Lấy boss hiện tại
    /// </summary>
    public GameObject GetCurrentBoss()
    {
        return currentBoss;
    }
}
