using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveStats
{
    public string waveName;
    public float delayBeforeStart = 2f;
    public List<EnemyEntry> enemyEntries = new List<EnemyEntry>();
}

[System.Serializable]
public class EnemyEntry
{
    public GameObject enemyPrefab;
    public int count = 5;
    public float spawnDelay = 0.5f;
    public bool isBoss = false;
}

