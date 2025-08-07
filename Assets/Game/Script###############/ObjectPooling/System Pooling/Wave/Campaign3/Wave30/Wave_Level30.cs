using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level30 : MonoBehaviour {

	public GameObject bossPrefab;
    public Vector3 spawnPosition = new Vector3(0, 5f, 0);

    void Start()
    {
        Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
    }
}
