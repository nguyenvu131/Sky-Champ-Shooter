using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gọi khi player chết:
//StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.4f));

public class CameraShakeMonster : MonoBehaviour {

	public IEnumerator Shake(float duration, float magnitude)
	{
		Vector3 originalPos = transform.localPosition;
		float elapsed = 0f;

		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;
			transform.localPosition = originalPos + new Vector3(x, y, 0);

			elapsed += Time.deltaTime;
			yield return null;
		}

		transform.localPosition = originalPos;
	}

//	public IEnumerator Shake(float duration, float magnitude)
//	{
//		Vector3 originalPos = transform.localPosition;
//		float elapsed = 0f;
//
//		while (elapsed < duration)
//		{
//			float x = Random.Range(-1f, 1f) * magnitude;
//			float y = Random.Range(-1f, 1f) * magnitude;
//
//			transform.localPosition = originalPos + new Vector3(x, y, 0);
//			elapsed += Time.unscaledDeltaTime;
//
//			yield return null;
//		}
//
//		transform.localPosition = originalPos;
//	}
}
