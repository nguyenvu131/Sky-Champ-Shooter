using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	public float lifeTime = 1.2f;

	void Start()
	{
		Destroy(gameObject, lifeTime);
	}
}
