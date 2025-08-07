using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletBase : MonoBehaviour {

	public float speed = 10f;
    public float damage = 20f;
    protected Vector3 direction = Vector3.up;

    public void SetDirection(Vector3 dir) {
        direction = dir.normalized;
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<MonsterStats>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
