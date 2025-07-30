using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMapData", menuName = "Map/MapData")]
public class MapData : ScriptableObject
{
    public int mapID;
    public string mapName;
    public Sprite[] backgrounds;
    public AudioClip bgm;
    public string description;

    public GameObject[] environmentPrefabs; // Meteor, obstacles,...
    public GameObject[] enemyPrefabs;       // Danh sách quái sẽ xuất hiện
	
	 public float[] scrollSpeeds;        // Tốc độ scroll cho từng lớp background
}
