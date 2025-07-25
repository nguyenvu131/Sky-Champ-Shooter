using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour {
    public List<PetData> equippedPets = new List<PetData>();
    public Transform firePoint;
    private float fireTimer = 0;

    void Update() {
        fireTimer += Time.deltaTime;
        for (int i = 0; i < equippedPets.Count; i++) {
            if (fireTimer >= 1f / equippedPets[i].fireRate) {
                Fire(equippedPets[i]);
            }
        }
    }

    void Fire(PetData pet) {
        GameObject bullet = ObjectPoolingManager.Instance.GetBullet(pet.bulletPrefab);
        bullet.transform.position = firePoint.position;
        bullet.SetActive(true);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null) {
            bulletScript.SetDirection(Vector3.up);
        }
        fireTimer = 0;
    }

    public void ActivateSkills() {
        for (int i = 0; i < equippedPets.Count; i++) {
            if (equippedPets[i].skillPrefab != null) {
                GameObject skill = Instantiate(equippedPets[i].skillPrefab);
                skill.SendMessage("ActivateSkill", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}