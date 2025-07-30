using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTextMonster : MonoBehaviour
{
    public Text popupText;
    public float moveUpDistance = 1f;
    public float duration = 1f;

    public void SetText(string text)
    {
        popupText.text = text;
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.up * moveUpDistance;
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            popupText.color = new Color(1, 1, 1, 1 - t); // fade out
            yield return null;
        }

        PopupTextPoolManager.Instance.ReturnToPool(gameObject);
    }
}
