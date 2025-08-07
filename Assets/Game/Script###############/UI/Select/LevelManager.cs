using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager Instance;

	public List<LevelData> levels = new List<LevelData>();

	public LevelData GetLevel(string levelName)
	{
		return levels.Find(l => l.levelName == levelName);
	}

	public void CompleteLevel(string levelName)
	{
		LevelData level = GetLevel(levelName);
		if (level != null)
		{
			level.completed = true;
			SaveSystem.SaveLevelData(level.levelName, true, true);
		}
	}

	public void UnlockLevel(string levelName)
	{
		LevelData level = GetLevel(levelName);
		if (level != null)
		{
			level.unlocked = true;
			SaveSystem.SaveLevelData(level.levelName, true, level.completed);
		}
	}
}
