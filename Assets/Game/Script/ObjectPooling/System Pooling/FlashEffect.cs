using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour {

	private Material mat;

    void Start()
    {
        // Clone material để không ảnh hưởng object khác
        mat = GetComponent<Renderer>().material;
        mat.SetFloat("_FlashAmount", 0);
    }

    public void TriggerFlash()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        mat.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.5f);
        mat.SetFloat("_FlashAmount", 0);
    }
}
