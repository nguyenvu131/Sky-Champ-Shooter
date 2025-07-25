using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//float damage = CombatCalculator.CalculateDamage(
//	attacker.atk,
//	target.def,
//	attacker.critRate,
//	attacker.critDmg,
//	skillMultiplier: 1.2f
//);
//
//target.TakeDamage(damage);
//PopupText.Show(damage.ToString(), target.transform.position, isCrit ? PopupType.Critical : PopupType.Damage);

public static class CombatCalculator
{
	public static float CalculateDamage(
		float atk, float def,
		float critRate, float critMultiplier,
		float skillMultiplier = 1f,
		float defenseMultiplier = 0.5f
	)
	{
		bool isCrit = Random.value < critRate;

		float damage = (atk * skillMultiplier) - (def * defenseMultiplier);
		damage = Mathf.Max(damage, 1f); // Không bao giờ dưới 1

		if (isCrit)
			damage *= critMultiplier;

		damage *= Random.Range(0.9f, 1.1f); // Biến thiên nhẹ

		return Mathf.Round(damage);
	}
}