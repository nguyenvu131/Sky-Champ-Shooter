using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour {

	public int value = 10;

//	private Transform player;
//
//	void Start()
//	{
//		player = GameObject.FindGameObjectWithTag("Player").transform;
//	}
//
//	void Update()
//	{
//		float dist = Vector3.Distance(transform.position, player.position);
//		if (dist < 3f)
//		{
//			transform.position = Vector3.MoveTowards(transform.position, player.position, 5f * Time.deltaTime);
//		}
//	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerCurrency.Instance.AddGold(value);
			Destroy(gameObject);
		}
	}
}
