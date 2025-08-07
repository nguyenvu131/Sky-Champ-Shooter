using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLife : MonoBehaviour
{
    public MonsterSpawner spawnerRef;
    public GameObject monsterObject;

    public void Die()
    {
        // Gọi NotifyMonsterDied nếu đã gán
        if (spawnerRef != null)
        {
            spawnerRef.NotifyMonsterDied(monsterObject);
        }

        Destroy(gameObject);
    }
}
