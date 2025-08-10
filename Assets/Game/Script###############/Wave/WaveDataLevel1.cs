using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDataLevel1 {
    public static List<EnemySpawnInfo> GetWaves() {
        return new List<EnemySpawnInfo> {
            new EnemySpawnInfo(0f, "monster1", new Vector2(0, 6)),
            new EnemySpawnInfo(2f, "monster1", new Vector2(-2, 6)),
            new EnemySpawnInfo(4f, "monster1", new Vector2(2, 6)),
            new EnemySpawnInfo(6f, "monster1", new Vector2(-1, 6)),
            new EnemySpawnInfo(8f, "monster1", new Vector2(1, 6)),

            new EnemySpawnInfo(20f, "monster1Dotween", new Vector2(0, 6)),
            new EnemySpawnInfo(22f, "monster1Dotween", new Vector2(-2, 6)),
            new EnemySpawnInfo(24f, "monster1Dotween", new Vector2(2, 6)),
            new EnemySpawnInfo(26f, "monster1Dotween", new Vector2(-1, 6)),
            new EnemySpawnInfo(28f, "monster1Dotween", new Vector2(1, 6)),

            new EnemySpawnInfo(40f, "monster1", new Vector2(-2, 6)),
            new EnemySpawnInfo(42f, "monster1Dotween", new Vector2(2, 6)),
            new EnemySpawnInfo(44f, "monster1", new Vector2(0, 6)),
            new EnemySpawnInfo(46f, "monster1Dotween", new Vector2(-1, 6)),
            new EnemySpawnInfo(48f, "monster1", new Vector2(1, 6)),
        };
    }
}