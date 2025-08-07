using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet0 : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 5f;
    public string bulletID = "DefaultMonsterBullet";

    private float timer = 0f;

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            MonsterBulletPoolManager.Instance.ReturnBullet(bulletID, gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Gây sát thương tại đây nếu cần
            MonsterBulletPoolManager.Instance.ReturnBullet(bulletID, gameObject);
        }
    }
}
