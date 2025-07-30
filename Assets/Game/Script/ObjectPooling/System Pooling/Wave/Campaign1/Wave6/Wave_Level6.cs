using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level6 : MonoBehaviour {

	public GameObject shieldBugPrefab;
    public GameObject slimePrefab;

    public float startX = 10f;
    public float baseY = 1.5f;
    public float ySpacing = -1.8f;
    public float pairSpacing = 0.8f;

    void Start()
    {
        SpawnShieldFormation();
    }

    void SpawnShieldFormation()
    {
        for (int i = 0; i < 2; i++)
        {
            float y = baseY + i * ySpacing;

            // Spawn Shield Bug (bay trước)
            Vector3 shieldPos = new Vector3(startX, y, 0);
            GameObject shield = Instantiate(shieldBugPrefab, shieldPos, Quaternion.identity);
            shield.GetComponent<MonsterMove6>().SetDirection(Vector3.left);

            // Spawn Slime (ẩn sau, cách shield chút xíu)
            Vector3 slimePos = new Vector3(startX + pairSpacing, y, 0);
            GameObject slime = Instantiate(slimePrefab, slimePos, Quaternion.identity);
            slime.GetComponent<MonsterMove6>().SetDirection(Vector3.left);
        }
    }
}
