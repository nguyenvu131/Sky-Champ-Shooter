using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 10f;
	public int damage = 1;

	public Vector3 direction;
	public GameObject hitEffect; //
	
	public int baseDamage = 10;
	public Player player;
    public PlayerStats stats;
	
    public void SetDamage(int dmg)
    {
        damage = dmg;
    }

	public void SetDirection(Vector3 dir)
	{
		direction = dir.normalized;
	}
		
	void Start()
    {
        // player = GameObject.FindWithTag("Player").GetComponent<Player>();
        baseDamage = stats.ATK;
    }
	
	void Update()
	{
		transform.Translate(Vector3.up * speed * Time.deltaTime);

		// Nếu đi quá xa màn hình thì ẩn
		// if (transform.position.y > 10f || transform.position.y < -10f)
		// {
			// gameObject.SetActive(false);
		// }

//		transform.position += direction * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Monster"))
		{
			// other.GetComponent<Monster>().TakeDamage(baseDamage);
			// other.GetComponent<Monster>().TakeDamage(damage);
			Monster monster = other.GetComponent<Monster>();
			if (monster != null)
			{
				monster.TakeDamage(damage);
			}
			// Destroy(gameObject);
			
			//
			if (hitEffect != null)
			{
				EffectPoolManager.Instance.SpawnEffect("hit", transform.position, Quaternion.identity);
			}
				

			// Gọi hàm trừ máu enemy nếu cần
//			other.GetComponent<Enemy>().TakeDamage(damage);
			//
			gameObject.SetActive(false);
		}
		
		if (other.CompareTag("Wall"))
		{
			// Xử lý va chạm với Player
			
			gameObject.SetActive(false);
		}
		
	}	
	
	void OnBecameInvisible()
	{
		gameObject.SetActive(false); // Tự tắt khi ra khỏi màn hình
	}
}
