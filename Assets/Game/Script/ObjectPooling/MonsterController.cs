using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour, IPoolableMonster
{
	public float speed = 2f;
	public float lifeTime = 6f;

	public virtual void OnSpawn()
	{
		CancelInvoke();
		Invoke("Disable", lifeTime);
	}

	void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

	void Disable()
	{
		gameObject.SetActive(false);
	}
}
