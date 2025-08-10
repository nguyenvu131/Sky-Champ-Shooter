using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDataLevel2 {
    public static List<EnemySpawnInfo> GetWaves() {
        return new List<EnemySpawnInfo> {
            // Wave 1: EnemyTypeA di chuyển ngang chậm
            new EnemySpawnInfo(0f,  "EnemyTypeA_MoveLeft",  new Vector2(2, 6)),
            new EnemySpawnInfo(1.5f,"EnemyTypeA_MoveRight", new Vector2(-2, 6)),
            new EnemySpawnInfo(3f,  "EnemyTypeA_MoveLeft",  new Vector2(1, 6)),
            new EnemySpawnInfo(4.5f,"EnemyTypeA_MoveRight", new Vector2(-1, 6)),

            // Wave 2: EnemyTypeB di chuyển zigzag
            new EnemySpawnInfo(10f, "EnemyTypeB_Zigzag",    new Vector2(0, 6)),
            new EnemySpawnInfo(11.5f,"EnemyTypeB_Zigzag",   new Vector2(2, 6)),
            new EnemySpawnInfo(13f, "EnemyTypeB_Zigzag",    new Vector2(-2, 6)),
            new EnemySpawnInfo(14.5f,"EnemyTypeB_Zigzag",   new Vector2(1, 6)),
            new EnemySpawnInfo(16f, "EnemyTypeB_Zigzag",    new Vector2(-1, 6)),

            // Wave 3: Kết hợp EnemyTypeA & B
            new EnemySpawnInfo(22f, "EnemyTypeA_MoveLeft",  new Vector2(-2, 6)),
            new EnemySpawnInfo(23f, "EnemyTypeB_Zigzag",    new Vector2(2, 6)),
            new EnemySpawnInfo(24f, "EnemyTypeA_MoveRight", new Vector2(0, 6)),
            new EnemySpawnInfo(25f, "EnemyTypeB_Zigzag",    new Vector2(-1, 6)),
            new EnemySpawnInfo(26f, "EnemyTypeA_MoveLeft",  new Vector2(1, 6)),

            // Mini-boss cuối màn
            new EnemySpawnInfo(40f, "MiniBoss_MoveSlow",    new Vector2(0, 6)),
        };
    }
}
