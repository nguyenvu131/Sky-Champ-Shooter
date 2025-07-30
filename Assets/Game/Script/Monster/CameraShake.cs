using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2. Rung camera
//if (cameraShake != null)
//	cameraShake.Shake(0.2f, 0.1f);
//StartCoroutine(cameraShake.Shake(0.3f, 0.2f));

public class CameraShake : MonoBehaviour {

	public IEnumerator Shake(float duration, float magnitude)
	{
		Vector3 originalPos = transform.localPosition;

		float elapsed = 0.0f;

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

	public void Shake() {
		Shake(0.2f, 0.1f);
	}
}
