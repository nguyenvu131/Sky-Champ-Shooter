using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave22_ShieldCore : MonoBehaviour {

	public GameObject corePrefab;
    public GameObject satellitePrefab;
    public int satelliteCount = 6;
    public float radius = 1.5f;

    private GameObject coreInstance;
    private List<GameObject> satellites = new List<GameObject>();

    void Start()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        // Spawn Core ở giữa
        Vector3 corePos = new Vector3(0, 5f, 0);
        coreInstance = Instantiate(corePrefab, corePos, Quaternion.identity);

        // Spawn vệ tinh quay quanh core
        for (int i = 0; i < satelliteCount; i++)
        {
            float angle = i * Mathf.PI * 2 / satelliteCount;
            Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Vector3 satellitePos = corePos + offset;

            GameObject satellite = Instantiate(satellitePrefab, satellitePos, Quaternion.identity);
            ShieldSatellite satelliteScript = satellite.GetComponent<ShieldSatellite>();
            satelliteScript.core = coreInstance.transform;
            satelliteScript.angle = angle;
            satelliteScript.radius = radius;

            satellites.Add(satellite);
        }

        // Gán danh sách vệ tinh cho Core
        // ShieldCore coreScript = coreInstance.GetComponent<ShieldCore>();
        // coreScript.satellites = satellites;
    }
}
