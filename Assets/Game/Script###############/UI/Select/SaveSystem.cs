using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour {

	public static void SaveLevelData(string levelName, bool unlocked, bool completed)
	{
		PlayerPrefs.SetInt(levelName + "_unlocked", unlocked ? 1 : 0);
		PlayerPrefs.SetInt(levelName + "_completed", completed ? 1 : 0);
	}

	public static void LoadLevelData(LevelData level)
	{
		level.unlocked = PlayerPrefs.GetInt(level.levelName + "_unlocked", level.unlocked ? 1 : 0) == 1;
		level.completed = PlayerPrefs.GetInt(level.levelName + "_completed", level.completed ? 1 : 0) == 1;
	}
}
