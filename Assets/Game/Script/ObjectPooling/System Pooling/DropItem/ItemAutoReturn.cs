using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAutoReturn : MonoBehaviour
{
    public float lifeTime = 10f;
    private float timer;

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            DropItemPoolManager.Instance.ReturnToPool(gameObject);
        }
    }
}
