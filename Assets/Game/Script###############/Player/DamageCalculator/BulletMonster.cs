using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMonster : MonoBehaviour 
{
	public PlayerStats stats;
	
	public float baseDmg = 10f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		DamageReceiver receiver = col.GetComponent<DamageReceiver>();
		if (receiver != null)
		{
			
			DamageInfo dmg = new DamageInfo(baseDmg, stats.atk);
			dmg.skillMultiplier = 1.2f;
			dmg.critChance = 0.2f;
			dmg.critMultiplier = 2.5f;

			receiver.TakeDamage(dmg);
		}

		Destroy(gameObject); // hoặc trả về pool
	}
}
