using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountControllerMonster : MonoBehaviour {

	public Transform firePoint;
	private MountData data;
	private float fireTimer;
	private float skillTimer;

	public void Initialize(MountData mountData)
	{
		data = mountData;
		fireTimer = 0f;
		skillTimer = 0f;

		if (data.skillType == MountSkillType.Passive)
			ApplyPassiveEffect();
	}

	void Update()
	{
		if (data == null) return;

		// Tấn công thường
		fireTimer += Time.deltaTime;
		if (fireTimer >= 1f / data.fireRate)
		{
			fireTimer = 0f;
			Fire();
		}

		// Kỹ năng chủ động tự động (AutoTimed)
		if (data.skillType == MountSkillType.AutoTimed)
		{
			skillTimer += Time.deltaTime;
			if (skillTimer >= data.skillCooldown)
			{
				skillTimer = 0f;
				ActivateSkill();
			}
		}
	}

	void Fire()
	{
		GameObject bullet = Instantiate(data.bulletPrefab, firePoint.position, Quaternion.identity);
		bullet.GetComponent<MountBullet>().Init(data.attackDamage);
		if (data.fireSFX)
			AudioSource.PlayClipAtPoint(data.fireSFX, transform.position);
	}

	public void ActivateSkill()
	{
		if (data.skillEffectPrefab)
			Instantiate(data.skillEffectPrefab, transform.position, Quaternion.identity);

		// Ví dụ: Gây damage quanh player
		Collider[] hit = Physics.OverlapSphere(transform.position, 3f);
		foreach (Collider c in hit)
		{
			if (c.CompareTag("Enemy"))
			{
				var stats = c.GetComponent<CombatStats>();
				if (stats != null)
					stats.TakeDamage(data.skillPower);
			}
		}
	}

	void ApplyPassiveEffect()
	{
//		var playerStats = GameObject.FindWithTag("Player").GetComponent<CombatStats>();
//		playerStats.bonusCritRate += data.skillPower;  // ví dụ tăng crit%
	}
}
