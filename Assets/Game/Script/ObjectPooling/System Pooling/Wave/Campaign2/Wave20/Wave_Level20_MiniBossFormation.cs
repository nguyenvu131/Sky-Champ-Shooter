using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level20_MiniBossFormation : MonoBehaviour {

	public GameObject miniBossPrefab;

    void Start()
    {
        SpawnMiniBossFormation();
    }

    void SpawnMiniBossFormation()
    {
        Vector3[] positions = new Vector3[]
        {
            new Vector3(0, 6f, 0),     // Trung tâm
            new Vector3(-3f, 7f, 0),   // Trái trên
            new Vector3(3f, 7f, 0)     // Phải trên
        };

        foreach (Vector3 pos in positions)
        {
            GameObject boss = Instantiate(miniBossPrefab, pos, Quaternion.identity);
            boss.AddComponent<MiniBossMovement>();
        }
    }
}
