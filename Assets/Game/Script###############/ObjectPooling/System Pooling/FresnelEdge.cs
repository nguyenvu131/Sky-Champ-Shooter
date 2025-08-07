using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FresnelEdge : MonoBehaviour {

	public Color fresnelColor = new Color(0.5f, 0.8f, 1f, 1f);
    public float fresnelPower = 2f;
    public bool pulseEffect = false;
    public float pulseSpeed = 2f;

    private Material instanceMat;
    private float basePower;

    void Start()
    {
        // Clone material để không ảnh hưởng material gốc
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            instanceMat = renderer.material;
            instanceMat.shader = Shader.Find("Custom/FresnelEdge");

            instanceMat.SetColor("_FresnelColor", fresnelColor);
            instanceMat.SetFloat("_FresnelPower", fresnelPower);
            basePower = fresnelPower;
        }
        else
        {
            Debug.LogWarning("FresnelController: Renderer not found!");
        }
    }

    void Update()
    {
        if (instanceMat == null) return;

        // Hiệu ứng viền nhấp nháy nếu bật
        if (pulseEffect)
        {
            float pulse = basePower + Mathf.Sin(Time.time * pulseSpeed) * 1.0f;
            instanceMat.SetFloat("_FresnelPower", pulse);
        }
    }

    // Gọi từ code khác để đổi màu viền runtime
    public void SetFresnelColor(Color color)
    {
        fresnelColor = color;
        if (instanceMat != null)
            instanceMat.SetColor("_FresnelColor", fresnelColor);
    }

    // Gọi từ code khác để tăng độ sáng viền runtime
    public void SetFresnelPower(float power)
    {
        fresnelPower = power;
        basePower = power;
        if (instanceMat != null)
            instanceMat.SetFloat("_FresnelPower", fresnelPower);
    }
}
