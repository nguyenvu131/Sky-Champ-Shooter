using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAutoReturn : MonoBehaviour
{
   public float lifeTime = 1.5f;
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
            EffectPoolManager.Instance.ReturnToPool(gameObject);
        }
    }
}
