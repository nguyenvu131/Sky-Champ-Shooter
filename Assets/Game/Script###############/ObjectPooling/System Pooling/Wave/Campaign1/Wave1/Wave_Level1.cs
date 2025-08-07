using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level1 : MonoBehaviour
{
    [Header("Slime Settings")]
    public GameObject slimePrefab;        // Prefab của quái Slime
    public int slimeCount = 5;            // Số lượng slime cần spawn
    public float spawnInterval = 0.5f;    // Thời gian giữa các lần spawn
    public float startX = 9f;             // Tọa độ X để spawn
    public float startY = 6f;             // Tọa độ Y gốc
    public float ySpacing = -1.2f;        // Khoảng cách theo Y giữa các slime

    [Header("Parent Root (Optional)")]
    public Transform spawnRoot;           // Gốc để chứa slime tạo ra (tùy chọn)

    void Start()
    {
        StartCoroutine(SpawnSlimes());
    }

    IEnumerator SpawnSlimes()
    {
        for (int i = 0; i < slimeCount; i++)
        {
            Vector3 spawnPos = new Vector3(startX, startY + i * ySpacing, 0);

            // Tạo slime bằng Instantiate
            GameObject slime = Instantiate(slimePrefab, spawnPos, Quaternion.identity, spawnRoot);

            // Gán hướng bay trái nếu có MonsterMove1
            var move = slime.GetComponent<MonsterMove1>();
            if (move != null)
                move.SetDirection(Vector3.left);

            // Hủy slime sau 10 giây
            // Destroy(slime, 10f);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
