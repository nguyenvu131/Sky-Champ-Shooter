using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyDontDestroyOnLoad : MonoBehaviour
{
    public void RemoveDontDestroyOnLoad()
    {
        // Lấy scene hiện tại đang active
        Scene currentScene = SceneManager.GetActiveScene();

        // Di chuyển GameObject về scene hiện tại
        SceneManager.MoveGameObjectToScene(gameObject, currentScene);
    }
}
