using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEXP : MonoBehaviour {

	public PlayerStats stats;

	public void GainEXP(int amount) {
		// stats.currentExp += amount;
		// if (stats.exp >= stats.ExpToNextLevel()) {
			// LevelUp();
		// }
	}

	void LevelUp() {
		stats.level++;
		stats.expToNextLevel += 50;
		stats.maxHP += 20;
		stats.attack += 5;
		stats.currentHP = stats.maxHP;
	}
}
