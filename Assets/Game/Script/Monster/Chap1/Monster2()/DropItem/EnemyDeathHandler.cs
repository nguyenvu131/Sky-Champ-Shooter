using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour, IEnemyDeathListener 
{	
	public AudioSource audioSource;
	public AudioClip deathSound;
	public int scorePerEnemy = 10;
	public CameraShake cameraShake;

	public GameObject itemPrefab;

	void OnEnable()
	{
		GameEvents.Instance.RegisterEnemyDeathListener(this);
	}

	void OnDisable()
	{
		GameEvents.Instance.UnregisterEnemyDeathListener(this);
	}

	public void OnEnemyDeath(Monster enemy)
	{
		Debug.Log("Enemy died: " + enemy.name);
		// Xử lý logic khi enemy chết tại đây (ví dụ: cộng điểm, drop item, rung camera...)
		Vector3 pos = enemy.transform.position;

		// 1. Drop từng item trong drop table nếu trúng tỉ lệ
//		if (enemy.dropTable != null)
//		{
//			foreach (var drop in enemy.dropTable.dropItems)
//			{
//				if (Random.value < drop.dropChance)
//				{
//					PoolManager.Instance.SpawnFromPool(drop.poolTag, pos, Quaternion.identity);
//				}
//			}
//		}

		// 2. Rung camera
		if (cameraShake != null)
			cameraShake.Shake(0.2f, 0.1f);

		// 3. Âm thanh
		if (audioSource != null && deathSound != null)
			audioSource.PlayOneShot(deathSound);

		// 4. Cộng điểm
//		GameManager.Instance.AddScore(scorePerEnemy);
	}

	void Die()
	{
		Instantiate(itemPrefab, transform.position, Quaternion.identity);
		//		PoolManager.Instance.SpawnFromPool("Coin", transform.position, Quaternion.identity); thay bang pool
		Destroy(gameObject);

		if (Random.value < 0.5f)
		{
			Instantiate(itemPrefab, transform.position, Quaternion.identity);
		}
	}


}
