using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager Instance { get; private set; }

	public int MaxHP = 100;
	public int CurrentHP;
	public float Energy = 100f;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	public void TakeDamage(int dmg)
	{
		CurrentHP -= dmg;
		if (CurrentHP <= 0)
			GameManager.Instance.GameOver();
	}
}
