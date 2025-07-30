using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour {

	public float lifetime = 2f;

	void OnEnable()
	{
		CancelInvoke();
		Invoke("DisableObject", lifetime);
	}

	void DisableObject()
	{
		gameObject.SetActive(false);
	}
}
