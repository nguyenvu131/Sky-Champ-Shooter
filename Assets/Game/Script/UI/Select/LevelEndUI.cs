﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndUI : MonoBehaviour {

	// thời gian tối đa để đạt 3 sao
	public float currentTime;
	public int maxHP;
	public int remainingHP;

	public float totalTimeLimit = 60f;         // Thời gian tối đa (giới hạn)
	public float timeLimitFor3Stars = 30f;     // Giới hạn thời gian để được 3 sao
	public float timeLimitFor2Stars = 45f;     // Giới hạn thời gian để được 2 sao

	public int stars = 0;

	public void StartTracking(float hp)
	{
		currentTime = 0;
		maxHP = (int)hp;
	}

	void Update()
	{
		currentTime += Time.deltaTime;
	}

//	public int CalculateStars()
//	{
//		int stars = 1;
//
//		float hpPercent = (float)remainingHP / maxHP;
//		if (hpPercent >= 0.6f) stars++;
//		if (currentTime <= totalTimeLimit) stars++;

//		SaveSystem.SaveLevelStars(currentLevelName, stars);
//		return stars;
//	} 

	public void CalculateStar(float currentTime)
	{
		stars = 1; // Mặc định 1 sao nếu hoàn thành

		if (currentTime <= timeLimitFor2Stars)
			stars = 2;

		if (currentTime <= timeLimitFor3Stars)
			stars = 3;

		Debug.Log("Số sao đạt được: " + stars);
	}
}
