using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyWave3 : MonoBehaviour {

	public float lifeTime = 2f;
    void Start() { Destroy(gameObject, lifeTime); }
}
