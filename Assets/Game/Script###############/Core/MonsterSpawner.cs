using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int count = 5;
    public float interval = 0.5f;
    public Transform spawnRoot;
    public Vector3 startPos;
    public Vector3 offset;

    public Action<GameObject> OnMonsterSpawned;
    public Action<GameObject> OnMonsterDied;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = startPos + offset * i;
            GameObject monster = Instantiate(monsterPrefab, pos, Quaternion.identity) as GameObject;

            if (spawnRoot != null)
            {
                monster.transform.SetParent(spawnRoot, false);
            }

            MonsterLife life = monster.GetComponent<MonsterLife>();
            if (life != null)
            {
                life.spawnerRef = this; // Truyền tham chiếu nếu cần gọi OnMonsterDied từ MonsterLife
                life.monsterObject = monster;
            }

            if (OnMonsterSpawned != null)
            {
                OnMonsterSpawned(monster);
            }

            yield return new WaitForSeconds(interval);
        }
    }

    // Hàm gọi từ MonsterLife khi chết
    public void NotifyMonsterDied(GameObject monster)
    {
        if (OnMonsterDied != null)
        {
            OnMonsterDied(monster);
        }
    }
}
