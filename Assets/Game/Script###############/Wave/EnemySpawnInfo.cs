using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawnInfo
{
    public float spawnTime;
    public string enemyType;
    public Vector2 spawnPosition;

    public EnemySpawnInfo(float spawnTime, string enemyType, Vector2 spawnPosition)
    {
        this.spawnTime = spawnTime;
        this.enemyType = enemyType;
        this.spawnPosition = spawnPosition;
    }
}
