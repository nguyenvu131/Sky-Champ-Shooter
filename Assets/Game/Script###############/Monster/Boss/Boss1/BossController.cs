using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
	Idle,
	Move,
	Attack,
	Special,
	Dead
}

public class BossController : MonoBehaviour, IPoolableMonster {

	public BossState currentState = BossState.Idle;

	public float moveSpeed = 2f;
	public float attackCooldown = 2f;
	public Transform[] moveTargets;

	private int currentTarget = 0;

	public void OnSpawn()
	{
		currentState = BossState.Move;
		CancelInvoke();
		InvokeRepeating("UpdateFSM", 0f, 0.2f);
	}

	void UpdateFSM()
	{
		switch (currentState)
		{
		case BossState.Idle:
			// Đứng yên 1 chút rồi chuyển sang Move
			Invoke("SwitchToMove", 1f);
			break;

		case BossState.Move:
			MoveToTarget();
			break;

		case BossState.Attack:
			Shoot();
			currentState = BossState.Idle;
			break;

		case BossState.Special:
			DoSpecialSkill();
			currentState = BossState.Idle;
			break;

		case BossState.Dead:
			OnDead();
			break;
		}
	}

	void SwitchToMove()
	{
		currentState = BossState.Move;
	}

	void MoveToTarget()
	{
		if (moveTargets.Length == 0) return;

		Transform target = moveTargets[currentTarget];
		transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.position) < 0.5f)
		{
			currentTarget = (currentTarget + 1) % moveTargets.Length;
			currentState = Random.value > 0.5f ? BossState.Attack : BossState.Special;
		}
	}

	void Shoot()
	{
		Debug.Log("Boss bắn!");
		PoolManager.Instance.SpawnFromPool("BossBullet", transform.position, Quaternion.identity);
	}

	void DoSpecialSkill()
	{
		Debug.Log("Boss dùng skill đặc biệt!");
		// Gọi skill đặc biệt từ Pool
		PoolManager.Instance.SpawnFromPool("BossLaser", transform.position, Quaternion.identity);
	}

	public void TakeDamage(float dmg)
	{
		// Giả sử máu giảm, nếu <= 0 thì chết
		currentState = BossState.Dead;
	}

	void OnDead()
	{
		CancelInvoke();
		PoolManager.Instance.SpawnFromPool("Explosion", transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}

	void OnDisable()
	{
		CancelInvoke();
	}
}
