using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
	public string levelName;
	public string sceneName;
	public string description;
	public Sprite background;
	public bool unlocked;
	public bool completed;
	public int requiredLevel; // Mở khi nhân vật đạt cấp này

	public int starAchieved = 0; //  Lưu số sao đã đạt
}
