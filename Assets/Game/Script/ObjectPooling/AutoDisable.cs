using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour {

	public float duration = 5f;

	void OnEnable()
	{
		CancelInvoke();
		Invoke("Disable", duration);
	}

	void Disable()
	{
		gameObject.SetActive(false);
	}
}
