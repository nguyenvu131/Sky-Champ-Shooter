using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level16 : MonoBehaviour {

	public GameObject monsterPrefab;
    public int numberPerSide = 4;
    public float spacingY = 1.5f;
    public float spawnOffsetX = 7f; // khoảng cách spawn ngoài màn hình
    public Transform centerY;

    void Start()
    {
        SpawnSideAmbush();
    }

    void SpawnSideAmbush()
    {
        for (int i = 0; i < numberPerSide; i++)
        {
            float offsetY = (i - numberPerSide / 2) * spacingY;

            // Spawn bên trái
            Vector3 leftPos = new Vector3(-spawnOffsetX, centerY.position.y + offsetY, 0);
            GameObject leftMonster = Instantiate(monsterPrefab, leftPos, Quaternion.identity);
            var leftAI = leftMonster.GetComponent<MonsterSideAmbush>();
            if (leftAI != null) leftAI.SetDirection(Vector2.right + Vector2.down);

            // Spawn bên phải
            Vector3 rightPos = new Vector3(spawnOffsetX, centerY.position.y + offsetY, 0);
            GameObject rightMonster = Instantiate(monsterPrefab, rightPos, Quaternion.identity);
            var rightAI = rightMonster.GetComponent<MonsterSideAmbush>();
            if (rightAI != null) rightAI.SetDirection(Vector2.left + Vector2.down);
        }
    }
}
