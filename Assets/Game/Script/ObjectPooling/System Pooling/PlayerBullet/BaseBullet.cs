using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public string bulletID;
    public float speed = 10f;
    public float lifeTime = 3f;

    private float timer;

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            PlayerBulletPoolManager.Instance.ReturnToPool(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Apply damage here (optional)
            Debug.Log("Bullet hit enemy!");

            PlayerBulletPoolManager.Instance.ReturnToPool(gameObject);
        }
    }
}
