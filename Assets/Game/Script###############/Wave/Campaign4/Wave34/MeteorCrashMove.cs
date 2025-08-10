using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCrashMove : MonoBehaviour {

	public float fallSpeed = 6f;
    public bool hasExplosion = false;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            if (hasExplosion)
                TriggerExplosion();

            Destroy(gameObject);
        }
    }

    void TriggerExplosion()
    {
        // Gắn Particle ở đây
        // Gây damage nếu cần
        Debug.Log("💥 Meteor exploded!");
        // Example: Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
    }
}
