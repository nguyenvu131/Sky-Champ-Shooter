using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Button HomeButton;
	public Button Wave1Button;
	public Button Wave2Button;

    void Start()
    {
        HomeButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Home"); // chuyển đến scene GamePlay
        });
		Wave1Button.onClick.AddListener(() => {
            SceneManager.LoadScene("Wave1"); // chuyển đến scene GamePlay
        });
		Wave2Button.onClick.AddListener(() => {
            SceneManager.LoadScene("Loading"); // chuyển đến scene GamePlay
        });
    }
}
