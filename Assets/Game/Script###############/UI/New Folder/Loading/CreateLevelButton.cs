using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLevelButton : MonoBehaviour {

	public Button btn; // Gán qua Inspector hoặc GetComponent<Button>()
	public LevelData level; // Giả sử level là ScriptableObject hoặc struct chứa tên scene

	// Use this for initialization
	void Start()
	{
		btn.onClick.AddListener(() =>
			{
				// Gọi LoadSceneAsync với tên scene từ level
				SceneLoader.Instance.LoadSceneAsync(level.sceneName);
			});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
