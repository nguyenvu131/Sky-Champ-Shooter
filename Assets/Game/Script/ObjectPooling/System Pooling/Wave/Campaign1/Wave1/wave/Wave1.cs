using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour {

	[Header("Monster Settings")]
    public GameObject[] monsterPrefabs;   // Các loại prefab quái vật để random
    public int numberOfMonsters = 5;      // Số lượng quái trong hàng ngang
    public float spacing = 1.5f;          // Khoảng cách giữa mỗi con
    public float topY = 8f;               // Vị trí Y ở top màn hình

    void Start()
    {
        SpawnWave1();
    }

    void SpawnWave1()
    {
        float startX = -(numberOfMonsters - 1) * spacing / 2f;

        for (int i = 0; i < numberOfMonsters; i++)
        {
            Vector3 spawnPos = new Vector3(startX + i * spacing, topY, 0);

            // Random một monster từ danh sách
            int randomIndex = Random.Range(0, monsterPrefabs.Length);
            GameObject monsterToSpawn = monsterPrefabs[randomIndex];

            Instantiate(monsterToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
