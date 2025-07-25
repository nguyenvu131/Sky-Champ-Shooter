using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountController : MonoBehaviour {

	public Transform firePoint;
	private MountData data;
	private float fireTimer;

	public void Initialize(MountData mountData)
	{
		data = mountData;
		fireTimer = 0f;
	}

	void Update()
	{
		if (data == null) return;

		fireTimer += Time.deltaTime;
		if (fireTimer >= 1f / data.fireRate)
		{
			fireTimer = 0f;
			Fire();
		}

		// Optional: Di chuyển nhẹ
		transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(1f, 0.5f, 0), Time.deltaTime * 2f);
	}

	void Fire()
	{
		GameObject bullet = Instantiate(data.bulletPrefab, firePoint.position, Quaternion.identity);
		bullet.GetComponent<MountBullet>().Init(data.attackDamage);

		if (data.fireSFX)
			AudioSource.PlayClipAtPoint(data.fireSFX, transform.position);
	}
}
