using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// hệ thống AI né đạn (AI_EvadeBullet)
public class AI_EvadeBullet : MonoBehaviour {

	public float moveSpeed = 5f;
	public float evadeDistance = 3f;
	public LayerMask bulletLayer;
	public float evadeRadius = 2f;

	private Vector3 evadeDirection;

	void Update()
	{
		Collider2D bullet = Physics2D.OverlapCircle(transform.position, evadeRadius, bulletLayer);
		if (bullet)
		{
			Vector3 dirToBullet = bullet.transform.position - transform.position;
			evadeDirection = Vector3.Cross(dirToBullet, Vector3.forward).normalized;
		}

		transform.position += evadeDirection * moveSpeed * Time.deltaTime;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, evadeRadius);
	}
}
