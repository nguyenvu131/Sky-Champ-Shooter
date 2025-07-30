using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FriendStats : MonoBehaviour 
{
	public PlayerStats stats;


	public void Heal(int amount)
	{
		stats.currentHP = Mathf.Min(stats.currentHP + amount, stats.maxHP);
		Debug.Log("Player healed: " + amount);
	}
}
