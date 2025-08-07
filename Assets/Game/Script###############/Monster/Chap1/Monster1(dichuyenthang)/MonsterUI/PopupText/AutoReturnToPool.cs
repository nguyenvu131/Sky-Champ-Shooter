using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReturnToPool : MonoBehaviour {

	public float lifetime = 2.5f;//1.2f

	void OnEnable()
	{
		CancelInvoke();
		Invoke("Return", lifetime);
	}

	void Return()
	{
		GetComponent<PopupText>().ReturnToPool();
	}
}
