using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level35 : MonoBehaviour {

	public GameObject mirrorClonePrefab;
    public Transform spawnRoot;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnMirrorClones());
    }

    IEnumerator SpawnMirrorClones()
    {
        int initialCount = 5;
        for (int i = 0; i < initialCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-2f, 2f), Random.Range(4f, 6f), 0);
            GameObject clone = Instantiate(mirrorClonePrefab, pos, Quaternion.identity, spawnRoot);

            MirrorCloneBehavior behavior = clone.AddComponent<MirrorCloneBehavior>();
            behavior.isMainClone = true;
            behavior.maxSplits = 2;

            spawnedEnemies.Add(clone);
            yield return new WaitForSeconds(0.6f);
        }
    }
}
