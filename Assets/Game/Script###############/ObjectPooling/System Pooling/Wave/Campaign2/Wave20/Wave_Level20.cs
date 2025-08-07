using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level20 : MonoBehaviour {

	 public GameObject enemyZigzag;
    public GameObject enemySwarm;
    public GameObject enemyCharger;
    public GameObject miniBoss;

    void Start()
    {
        StartCoroutine(FinalBarrage());
    }

    IEnumerator FinalBarrage()
    {
        // Phase 1: Zigzag
        for (int i = 0; i < 3; i++)
        {
            Spawn(enemyZigzag, new Vector3(-4 + i * 4, 6f, 0));
        }
        yield return new WaitForSeconds(2f);

        // Phase 2: Swarm
        for (int i = 0; i < 5; i++)
        {
            float x = Random.Range(-4f, 4f);
            Spawn(enemySwarm, new Vector3(x, 6f + i * 0.5f, 0));
        }
        yield return new WaitForSeconds(2f);

        // Phase 3: Chargers
        for (int i = 0; i < 3; i++)
        {
            Spawn(enemyCharger, new Vector3(-6 + i * 6, 6f, 0));
        }
        yield return new WaitForSeconds(2f);

        // Final Phase: Mini Boss
        Spawn(miniBoss, new Vector3(0, 7f, 0));
    }

    void Spawn(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
