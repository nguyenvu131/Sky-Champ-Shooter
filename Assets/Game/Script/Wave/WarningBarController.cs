using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// WarningBarController.Instance.ShowWarning("⚠️ BOSS SẮP XUẤT HIỆN!", 4f);

public class WarningBarController : MonoBehaviour {

	public static WarningBarController Instance;

    public GameObject warningBarPrefab;
    private GameObject currentBar;

    void Awake()
    {
        Instance = this;
    }

    public void ShowWarning(string message = "WARNING! BOSS INCOMING!", float duration = 3f)
    {
        if (currentBar != null) return;

        GameObject canvas = GameObject.Find("Canvas");
        warningBarPrefab = Resources.Load<GameObject>("UI/WarningBar");
        currentBar = Instantiate(warningBarPrefab, canvas.transform);

        Text text = currentBar.GetComponentInChildren<Text>();
        if (text != null) text.text = message;

        // Optionally play warning sound
        AudioSource audio = currentBar.GetComponent<AudioSource>();
        if (audio != null) audio.Play();

        StartCoroutine(HideAfterSeconds(duration));
    }

    IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(currentBar);
    }
}
