using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T _instance;
    public static T Instance {
        get {
            if (_instance == null) {
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null) {
                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
	{
		if (_instance == null)
		{
			_instance = this as T;

			if (transform.parent == null)
			{
				DontDestroyOnLoad(gameObject); // chỉ khi là root
			}
			else
			{
				// Debug.LogWarning(typeof(T).Name + " không phải là root object, nên không thể dùng DontDestroyOnLoad.");
			}
		}
		else if (_instance != this)
		{
			Destroy(gameObject);
		}
	}
}
