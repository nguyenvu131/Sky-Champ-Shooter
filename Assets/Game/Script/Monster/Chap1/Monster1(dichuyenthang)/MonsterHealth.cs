using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

	public MonsterStats stats;
	public GameObject hitEffect;
	
	
	
	void Start()
    {
		
    }

	public void TakeDamage(Vector3 position, float amount, bool isCrit = false)
	{
		stats.currentHP -= amount;

		

		string type = isCrit ? "crit" : "damage";
		string text = Mathf.RoundToInt(amount).ToString();
		PopupTextPoolManager.Instance.SpawnPopup(
			type,
			position + Vector3.up * 1.5f,
			text
		);

		Debug.Log("Monster took damage: " + amount);

		if (stats.currentHP <= 0)
		{

			stats.currentHP = 0;
			stats.isDead = true;
			Die();
			//			 Gây sát thương popup bay len
			//						PopupText.Create("-200", transform.position, PopupType.Damage);
			// destroy UI hoặc ẩn
			if (stats.monsterUI != null)
				stats.monsterUI.gameObject.SetActive(false);	
		}

	}

	void Die()
	{


		// Gọi hiệu ứng chết
		// Spawn effect
		EffectPoolManager.Instance.SpawnEffect("explosion", transform.position, Quaternion.identity);
		// Ẩn đối tượng

		PlayerEXP playerEXP = FindObjectOfType<PlayerEXP>();
		if (playerEXP != null && stats != null)
		{
			playerEXP.GainEXP(stats.expDrop);
		}

		// Gọi drop vật phẩm (nếu có)
		var drop = GetComponent<MonsterDrop>();
		if (drop != null) 
			drop.SpawnDrop();

		// Báo cho hệ thống khác biết (event, EXP...)
		// EventManager.Trigger("OnMonsterDied", this); ← nếu có

		gameObject.SetActive(false);
	}
}
