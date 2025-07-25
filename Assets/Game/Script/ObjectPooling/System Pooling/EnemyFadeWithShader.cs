using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFadeWithShader : MonoBehaviour
{
    public float fadeDuration = 2f;
    private Material mat;
    private float currentAlpha = 1f;
    private Renderer rend;

    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            mat = rend.material;
            currentAlpha = 1f;
            mat.SetFloat("_Alpha", 1f);
        }
    }

    public void StartFade()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            currentAlpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            mat.SetFloat("_Alpha", currentAlpha);
            yield return null;
        }

        mat.SetFloat("_Alpha", 0f);

        // Gọi return về pool hoặc ẩn enemy
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        if (mat != null)
        {
            currentAlpha = 1f;
            mat.SetFloat("_Alpha", 1f);
        }
    }
}
