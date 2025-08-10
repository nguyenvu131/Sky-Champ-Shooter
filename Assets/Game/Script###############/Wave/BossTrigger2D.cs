using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger2D : MonoBehaviour
{
    [Header("Trigger Settings")]
    public string waveName;               // Tên wave để spawn boss
    public bool spawnOnCollision = false; // Spawn khi va chạm vật lý
    public bool spawnOnTrigger = true;    // Spawn khi trigger
    private bool bossSpawned = false;     // Chỉ spawn 1 lần

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (spawnOnCollision && !bossSpawned && collision.gameObject.CompareTag("Player"))
        {
            TrySpawnBoss();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (spawnOnTrigger && !bossSpawned && other.CompareTag("Player"))
        {
            TrySpawnBoss();
        }
    }

    void TrySpawnBoss()
    {
        if (BossManager.Instance == null)
        {
            Debug.LogWarning("[BossTrigger2D] BossManager not found!");
            return;
        }

        // Tìm boss wave tương ứng
        var bossWave = BossManager.Instance.bossWaves.Find(b => b.waveName == waveName);
        if (bossWave != null)
        {
            BossManager.Instance.SpawnBoss(bossWave);
            bossSpawned = true;
            Debug.Log("[BossTrigger2D] Boss spawned for wave: " + waveName);
        }
        else
        {
            Debug.LogWarning("[BossTrigger2D] No boss wave found for: " + waveName);
        }
    }
}
