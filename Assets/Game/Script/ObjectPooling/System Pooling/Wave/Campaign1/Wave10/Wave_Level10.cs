using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level10 : MonoBehaviour {

	public GameObject miniBossPrefab;
    public Vector3 spawnPosition = new Vector3(0f, 6f, 0f); // từ trên giữa màn hình

    void Start()
    {
        // Hiệu ứng cảnh báo boss nếu có
        // Instantiate(bossWarningEffect, Vector3.zero, Quaternion.identity);

        SpawnMiniBoss();
    }

    void SpawnMiniBoss()
    {
        Instantiate(miniBossPrefab, spawnPosition, Quaternion.identity);
    }
}
