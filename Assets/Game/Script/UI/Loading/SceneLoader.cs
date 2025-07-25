using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public static SceneLoader Instance;

	public GameObject loadingUI;
	public UnityEngine.UI.Slider progressBar;
	public UnityEngine.UI.Text tipText;

	public string[] randomTips = new string[]
	{
		"“Võ công cao cường không bằng tâm tính ổn định.”",
		"“Kẻ thắng là kẻ kiên nhẫn nhất trên giang hồ.”",
		"“Hành tẩu giang hồ, không thể thiếu rượu và nghĩa khí.”"
	};

	public void LoadSceneAsync(string sceneName)
	{
		StartCoroutine(LoadSceneRoutine(sceneName));
	}

	IEnumerator LoadSceneRoutine(string sceneName)
	{
		loadingUI.SetActive(true);
		tipText.text = randomTips[Random.Range(0, randomTips.Length)];

		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
		async.allowSceneActivation = false;

		while (async.progress < 0.9f)
		{
			progressBar.value = async.progress;
			yield return null;
		}

		progressBar.value = 1f;
		yield return new WaitForSeconds(1f); // thời gian delay cuối

		async.allowSceneActivation = true;
	}
}
