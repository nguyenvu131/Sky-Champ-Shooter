using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSkillManager : MonoBehaviour {

	public enum SkillType
	{
		None,
		BurstShoot,
		HealPlayer,
		ShieldPlayer,
		SpecialEffect
	}

	[Header("Skill Settings")]
	public SkillType skillType = SkillType.BurstShoot;
	public float cooldown = 10f;

	[Header("Burst Shoot")]
	public GameObject bulletPrefab;
	public Transform firePoint;
	public int burstCount = 5;
	public float burstRate = 0.1f;

	[Header("Heal & Shield")]
	public FriendStats friendStats;
	public int healAmount = 20;
	public GameObject shieldPrefab;

	[Header("Special Effect")]
	public GameObject skillEffectPrefab;

	private float skillTimer;

	void Update()
	{
		skillTimer += Time.deltaTime;

		if (skillTimer >= cooldown)
		{
			skillTimer = 0;
			ActivateSkill();
		}
	}

	void ActivateSkill()
	{
		switch (skillType)
		{
		case SkillType.BurstShoot:
			StartCoroutine(BurstShoot());
			break;
		case SkillType.HealPlayer:
			if (friendStats != null)
				friendStats.Heal(healAmount);
			break;
		case SkillType.ShieldPlayer:
			if (friendStats != null && shieldPrefab != null)
				Instantiate(shieldPrefab, friendStats.transform.position, Quaternion.identity, friendStats.transform);
			break;
		case SkillType.SpecialEffect:
			if (skillEffectPrefab != null)
				Instantiate(skillEffectPrefab, transform.position, Quaternion.identity);
			break;
		}
	}

	IEnumerator BurstShoot()
	{
		for (int i = 0; i < burstCount; i++)
		{
			if (bulletPrefab != null && firePoint != null)
			{
				GameObject b = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
				b.GetComponent<Rigidbody2D>().velocity = Vector2.up * 8f;
			}
			yield return new WaitForSeconds(burstRate);
		}
	}
}
