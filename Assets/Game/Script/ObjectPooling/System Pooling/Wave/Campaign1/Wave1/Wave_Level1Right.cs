using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level1Right : MonoBehaviour {

	public GameObject slimePrefab; // Prefab của quái Slime
    public int slimeCount = 5;     // Số lượng slime
    public float spawnInterval = 0.5f; // Khoảng thời gian giữa các lần spawn
    public float startX = -20f;     // Tọa độ X để spawn
    public float startY = 0f;      // Tọa độ Y gốc
    public float ySpacing = -1.2f; // Khoảng cách theo Y giữa các slime

    void Start()
    {
        StartCoroutine(SpawnSlimes());
    }

    IEnumerator SpawnSlimes()
    {
        for (int i = 0; i < slimeCount; i++)
        {
            Vector3 spawnPos = new Vector3(startX, startY + i * ySpacing, 0);
            GameObject slime = Instantiate(slimePrefab, spawnPos, Quaternion.identity);
            slime.GetComponent<MonsterMoveRight>().SetDirection(Vector3.right); // Gán hướng bay
			Destroy(slime, 10f); // 👈 Tự hủy sau 10 giây
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
