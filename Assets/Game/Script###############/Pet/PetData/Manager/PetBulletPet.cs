using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletPet : MonoBehaviour {

	public float speed = 10f;
    private int damage;

    public void Init(int dmg) {
        damage = dmg;
    }

    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Enemy")) {
            col.GetComponent<Monster>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
