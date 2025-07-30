using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FormationSpawnInfo
{
    public GameObject prefab;
    public int count = 5;
    public float startTime = 0f;
    public float interval = 0.5f;
    public float startX = 9f;
    public float startY = 6f;
    public float ySpacing = -1.2f;
}
