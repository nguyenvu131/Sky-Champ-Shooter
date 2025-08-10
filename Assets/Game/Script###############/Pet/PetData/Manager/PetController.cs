using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour {

	public PetData data;
    public Transform firePoint;
    public float shootTimer = 0f;

    void Update() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f) {
            Shoot();
            shootTimer = data.GetAttackRate();
        }
    }

    public void Setup(PetData newData) {
        data = newData;
    }

    void Shoot() {
        GameObject bullet = PetBulletPool.Instance.GetBullet(data.type);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);
        bullet.GetComponent<PetBulletPet>().Init(data.GetDamage());
    }
}
