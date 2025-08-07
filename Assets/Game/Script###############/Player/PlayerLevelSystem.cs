using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int level;
    public int requiredExp;
    public int totalExp;
	////////////////////////
	
	public string levelName;
	public string sceneName;
	public string description;
	public Sprite background;
	public bool unlocked;
	public bool completed;
	public int requiredLevel; // Mở khi nhân vật đạt cấp này

	public int starAchieved = 0; //  Lưu số sao đã đạt
	
    public int levelNumber;
    public List<WaveData> waves;
}

public class PlayerLevelSystem : MonoBehaviour {

	public List<LevelData> levelList = new List<LevelData>();
    public int currentLevel = 1;
    public int currentExp = 0;

    void Start()
    {
        GenerateLevelData(10);
    }

    public void GainExp(int amount)
    {
        currentExp += amount;

        while (currentLevel < levelList.Count && currentExp >= levelList[currentLevel - 1].totalExp + levelList[currentLevel - 1].requiredExp)
        {
            currentLevel++;
            Debug.Log("Leveled Up to " + currentLevel);
        }
    }

    public void GenerateLevelData(int maxLevel)
    {
        levelList.Clear();
        int totalExp = 0;
        for (int i = 1; i <= maxLevel; i++)
        {
            int required = Mathf.RoundToInt(100 * i * Mathf.Pow(1.1f, i));
            LevelData data = new LevelData()
            {
                level = i,
                requiredExp = required,
                totalExp = totalExp
            };
            levelList.Add(data);
            totalExp += required;
        }
    }
}
