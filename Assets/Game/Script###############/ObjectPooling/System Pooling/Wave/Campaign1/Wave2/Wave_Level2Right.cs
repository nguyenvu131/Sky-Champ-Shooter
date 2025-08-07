using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level2Right : MonoBehaviour {

	public GameObject beePrefab;        // Prefab của quái Bee
    public int beeCount = 7;            // Số lượng Bee
    public float spawnInterval = 0.5f;  // Thời gian giữa các lượt spawn
    public float startX = -9.7f;          // Vị trí bắt đầu theo X
    public float startY = 10f;           // Vị trí trung tâm theo Y
    public float yOffsetRange = 3f;     // Ngẫu nhiên khoảng Y để tạo cảm giác sinh động
    public float destroyAfter = 10f;    // Thời gian tự hủy quái

    void Start()
    {
        StartCoroutine(SpawnBees());
    }

    IEnumerator SpawnBees()
    {
        for (int i = 0; i < beeCount; i++)
        {
            float randomYOffset = Random.Range(-yOffsetRange, yOffsetRange);
            Vector3 spawnPos = new Vector3(startX, startY + randomYOffset, 0);

            GameObject bee = Instantiate(beePrefab, spawnPos, Quaternion.identity);
            
            // Gán hướng di chuyển sang trái
            bee.GetComponent<MonsterMoveRight>().SetDirection(Vector3.right);

            Destroy(bee, destroyAfter); // Tự hủy sau X giây

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
