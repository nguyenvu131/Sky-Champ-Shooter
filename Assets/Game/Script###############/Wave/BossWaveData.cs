using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWaveData {
    public static List<EnemySpawnInfo> GetWaves() {
        return new List<EnemySpawnInfo> {
			
            new EnemySpawnInfo(0f, "Boss", new Vector2(0, 6)),
			
        };
    }
}