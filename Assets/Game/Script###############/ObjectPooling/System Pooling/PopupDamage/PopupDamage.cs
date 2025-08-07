using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDamage : MonoBehaviour
{
    public float moveUpSpeed = 50f;
    public float fadeDuration = 1f;

    private Text text;
    private Color originalColor;
    private float timer = 0f;

    void Awake()
    {
        text = GetComponent<Text>();
        originalColor = text.color;
    }

    void Update()
    {
        // Di chuyển lên
        transform.Translate(Vector3.up * moveUpSpeed * Time.deltaTime);

        // Đếm thời gian và fade
        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

        if (alpha <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage, Color color)
    {
        text.text = damage.ToString();
        text.color = color;
        originalColor = color; // Lưu lại để fade alpha
    }
}
