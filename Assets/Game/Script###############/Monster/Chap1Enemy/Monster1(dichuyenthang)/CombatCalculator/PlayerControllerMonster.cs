using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMonster : MonoBehaviour {

	public CombatStats stats;
	public GameObject shipModel;

	public void Revive()
	{
		stats.hp = stats.maxHp / 2;
		shipModel.SetActive(true);
		gameObject.SetActive(true);

		// Add shield hoặc hiệu ứng hồi sinh nếu muốn
		StartCoroutine(Invincibility(2f));
	}

	IEnumerator Invincibility(float time)
	{
		Collider col = GetComponent<Collider>();
		col.enabled = false;
		yield return new WaitForSeconds(time);
		col.enabled = true;
	}
}
