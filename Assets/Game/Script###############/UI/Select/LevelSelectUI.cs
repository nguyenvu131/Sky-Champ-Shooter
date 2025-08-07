using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectUI : MonoBehaviour {

	public GameObject levelSlotPrefab;
	public Transform levelContainer;

	void Start()
	{
		foreach (var level in LevelManager.Instance.levels)
		{
			SaveSystem.LoadLevelData(level);
			CreateLevelButton(level);
		}
	}

	void CreateLevelButton(LevelData level)
	{
		GameObject slot = Instantiate(levelSlotPrefab, levelContainer);
		slot.transform.Find("LevelName").GetComponent<Text>().text = level.levelName;
		slot.transform.Find("Background").GetComponent<Image>().sprite = level.background;
		slot.transform.Find("Description").GetComponent<Text>().text = level.description;

		Button btn = slot.GetComponent<Button>();

		if (!level.unlocked)
		{
			btn.interactable = false;
			slot.transform.Find("LockIcon").gameObject.SetActive(true);
		}
		else
		{
			slot.transform.Find("LockIcon").gameObject.SetActive(false);
			btn.onClick.AddListener(() => SceneManager.LoadScene(level.sceneName));
		}

		if (level.completed)
		{
			slot.transform.Find("CompleteIcon").gameObject.SetActive(true);
		}
	}


}
