using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonsterSkill : MonoBehaviour
{
	public string skillName;
	public float cooldown = 5f;
	protected float lastUsedTime = -Mathf.Infinity;

	public abstract void Activate();

	public bool IsReady()
	{
		return Time.time >= lastUsedTime + cooldown;
	}

	public void Use()
	{
		if (IsReady())
		{
			Activate();
			lastUsedTime = Time.time;
		}
	}
}
