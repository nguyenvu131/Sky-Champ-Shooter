using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour 
{

	public static MapManager Instance;

    [Header("Background Layers")]
    public SpriteRenderer[] backgroundRenderers;

    [Header("Environment Parent (Optional)")]
    public Transform environmentParent;

    private MapData currentMap;

    private List<GameObject> spawnedEnvironment = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void LoadMap(int level)
    {
        ClearMap();

        currentMap = Resources.Load<MapData>("Maps/Map_Level" + level);

        if (currentMap == null)
        {
            Debug.LogError(" Không tìm thấy Map_Level" + level);
            return;
        }

        LoadBackgrounds();
        LoadBGM();
        SpawnEnvironment();

        Debug.Log(" Load map thành công: Map_Level" + level);
    }

    private void ClearMap()
    {
        foreach (var obj in spawnedEnvironment)
        {
            if (obj != null)
                Destroy(obj);
        }

        spawnedEnvironment.Clear();
    }

    private void LoadBackgrounds()
    {
        for (int i = 0; i < backgroundRenderers.Length; i++)
        {
            if (i < currentMap.backgrounds.Length)
            {
                SpriteRenderer original = backgroundRenderers[i];
                original.sprite = currentMap.backgrounds[i];
                original.gameObject.SetActive(true);

                var scroller = original.GetComponent<BackgroundScroller>();
                if (scroller != null && i < currentMap.scrollSpeeds.Length)
                    scroller.scrollSpeed = currentMap.scrollSpeeds[i];

                // 👉 Clone để nối tiếp scroll
                GameObject clone = Instantiate(original.gameObject,
                    original.transform.position + new Vector3(0, original.bounds.size.y, 0),
                    Quaternion.identity);

                clone.transform.SetParent(original.transform.parent);

                var cloneScroller = clone.GetComponent<BackgroundScroller>();
                if (cloneScroller != null && i < currentMap.scrollSpeeds.Length)
                    cloneScroller.scrollSpeed = currentMap.scrollSpeeds[i];
            }
            else
            {
                backgroundRenderers[i].gameObject.SetActive(false);
            }
        }
    }

    private void LoadBGM()
    {
        // Tùy chọn mở lại nếu dùng âm nhạc
        // if (bgmAudio != null && currentMap.bgm != null)
        // {
        //     bgmAudio.clip = currentMap.bgm;
        //     bgmAudio.Play();
        // }
    }

    private void SpawnEnvironment()
	{
		if (currentMap.environmentPrefabs == null || currentMap.environmentPrefabs.Length == 0) return;

		foreach (var prefab in currentMap.environmentPrefabs)
		{
			if (prefab == null)
			{
				Debug.LogWarning(" Prefab môi trường null trong MapData! Kiểm tra lại Map_Level" + currentMap.name);
				continue;
			}

			Vector3 pos = RandomPosition();
			GameObject obj = Instantiate(prefab, pos, Quaternion.identity);

			if (environmentParent != null)
				obj.transform.SetParent(environmentParent);

			spawnedEnvironment.Add(obj);
		}
	}

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-3f, 3f), Random.Range(6f, 10f), 0);
    }

    public GameObject[] GetEnemyPrefabs()
    {
        return currentMap != null ? currentMap.enemyPrefabs : null;
    }

    public MapData GetCurrentMapData()
    {
        return currentMap;
    }
}
