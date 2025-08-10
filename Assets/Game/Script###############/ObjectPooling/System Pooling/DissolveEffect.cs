using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour {

	public Material dissolveMat;
    public float dissolveSpeed = 1f;
    private float dissolveAmount = 0f;
    private bool isDissolving = false;

    void Update()
    {
        if (isDissolving)
        {
            dissolveAmount += Time.deltaTime * dissolveSpeed;
            dissolveMat.SetFloat("_DissolveAmount", dissolveAmount);

            if (dissolveAmount >= 1f)
            {
                Destroy(gameObject); // Hoặc pool lại object
            }
        }
    }

    public void StartDissolve()
    {
        isDissolving = true;
    }
}
