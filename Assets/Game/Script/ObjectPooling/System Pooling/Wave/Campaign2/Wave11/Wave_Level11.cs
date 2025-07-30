using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level11 : MonoBehaviour {

	public GameObject monsterPrefab;         // Prefab quái
    public int rowCount = 2;                 // Số hàng trong chữ V
    public int monsterPerSide = 3;           // Số quái mỗi cạnh chữ V
    public float spacing = 1.5f;             // Khoảng cách giữa quái
    public float spawnDelay = 0.2f;          // Delay giữa mỗi lượt spawn
    public Transform spawnCenter;            // Điểm giữa đỉnh chữ V

    private List<GameObject> spawnedMonsters = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnVFormation());
    }

    IEnumerator SpawnVFormation()
    {
        for (int i = 0; i < monsterPerSide; i++)
        {
            Vector3 leftPos = spawnCenter.position + new Vector3(-spacing * (i + 1), -spacing * i, 0);
            Vector3 rightPos = spawnCenter.position + new Vector3(spacing * (i + 1), -spacing * i, 0);

            GameObject leftMonster = Instantiate(monsterPrefab, leftPos, Quaternion.identity);
            GameObject rightMonster = Instantiate(monsterPrefab, rightPos, Quaternion.identity);

            spawnedMonsters.Add(leftMonster);
            spawnedMonsters.Add(rightMonster);

            yield return new WaitForSeconds(spawnDelay);
        }

        // Spawn quái ở giữa (đỉnh chữ V)
        GameObject center = Instantiate(monsterPrefab, spawnCenter.position, Quaternion.identity);
        spawnedMonsters.Add(center);
    }
}
