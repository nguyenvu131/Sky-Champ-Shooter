using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level4 : MonoBehaviour {

	public GameObject miniDronePrefab;
    public int pairCount = 3; // Mỗi cặp 2 con: 1 trái, 1 phải
    public float spawnInterval = 0.8f;
    public float leftX = -10f;
    public float rightX = 10f;
    public float startY = 2f;
    public float ySpacing = -1.5f;

    void Start()
    {
        StartCoroutine(SpawnSideDrones());
    }

    IEnumerator SpawnSideDrones()
    {
        for (int i = 0; i < pairCount; i++)
        {
            float yPos = startY + i * ySpacing;

            // Spawn bên trái
            Vector3 leftPos = new Vector3(leftX, yPos, 0);
            GameObject droneL = Instantiate(miniDronePrefab, leftPos, Quaternion.identity);
            droneL.GetComponent<SideMove>().SetDirection(Vector3.right);

            // Spawn bên phải
            Vector3 rightPos = new Vector3(rightX, yPos, 0);
            GameObject droneR = Instantiate(miniDronePrefab, rightPos, Quaternion.identity);
            droneR.GetComponent<SideMove>().SetDirection(Vector3.left);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
