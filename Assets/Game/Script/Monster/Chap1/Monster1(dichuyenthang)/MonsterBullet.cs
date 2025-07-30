using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour 
{

	public float lifetime = 5f;
	public float damage;
	public float speed = 8f;
	
	private bool isCrit = false;

	void Start() 
	{
		Destroy(gameObject, lifetime); // tự huỷ sau thời gian
	}
	
	void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (transform.position.y < -6) ObjectPooler.Instance.ReturnToPool("MonsterBullet", gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			
			//PlayerHealth ph = other.GetComponent<PlayerHealth>();
			//if (ph != null) ph.TakeDamage(damage);
			
			other.GetComponent<PlayerStats>().TakeDamage(damage);
			ObjectPooler.Instance.ReturnToPool("MonsterBullet", gameObject);
			
			gameObject.SetActive(false);
		}
	}

	void OnEnable() {
		CancelInvoke();
		Invoke("Deactivate", 5f);
	}

	void Deactivate() {
		gameObject.SetActive(false);
	}
	
	public void Init(float dmg)
	{
		damage = dmg;
	}
	
	public void Init(float atk, float critRate, float critDmg)
	{
		damage = atk;
		isCrit = Random.Range(0f, 100f) < critRate;
		if (isCrit) damage *= critDmg / 100f;
	}
}
