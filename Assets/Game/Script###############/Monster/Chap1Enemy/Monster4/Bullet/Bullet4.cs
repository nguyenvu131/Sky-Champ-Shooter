using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4 : MonoBehaviour {

	public float lifeTime = 3f;

    void OnEnable()
    {
        CancelInvoke();
        Invoke("Deactivate", lifeTime);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
