using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarSystem : MonoBehaviour {

	public static LevelStarSystem Instance;

	public string currentLevelName;

	public float totalTimeLimit = 180f; // thời gian tối đa để đạt 3 sao
	public float currentTime;
	public int maxHP;
	public int remainingHP;

	public void StartTracking(float hp)
	{
		currentTime = 0;
		maxHP = (int)hp;
	}

	void Update()
	{
		currentTime += Time.deltaTime;
	}

	public int CalculateStars()
	{
		int stars = 1;

		float hpPercent = (float)remainingHP / maxHP;
		if (hpPercent >= 0.6f) stars++;
		if (currentTime <= totalTimeLimit) stars++;

//		SaveSystem.SaveLevelStars(currentLevelName, stars);
		return stars;
	}
}
