using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour {

	public float maxHp = 100;
	public float currentHp;

	public GameObject healthBarPrefab;
	private EnemyHealthBar hpBar;

	void Start()
	{
		currentHp = maxHp;

		GameObject bar = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
		hpBar = bar.GetComponent<EnemyHealthBar>();
		hpBar.Setup(transform, maxHp);
	}

	public void TakeDamage(float dmg)
	{
		currentHp -= dmg;
		currentHp = Mathf.Clamp(currentHp, 0, maxHp);

		hpBar.UpdateHealth(currentHp);

		if (currentHp <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
