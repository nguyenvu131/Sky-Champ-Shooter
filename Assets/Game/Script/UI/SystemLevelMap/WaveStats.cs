using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveData", menuName = "SkyChamp/WaveStatsMonster")]
public class WaveStats : ScriptableObject
{
    public int waveID;
    public SpawnInfo[] spawns;
	
	public FormationSpawnInfo[] formations; // 👈 THÊM DÒNG NÀY
}
