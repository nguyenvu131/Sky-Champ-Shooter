using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [System.Serializable]
    public delegate void MapLoadedDelegate(int mapIndex);
    public static MapLoadedDelegate OnMapLoaded;

    [Header("Map Settings")]
    public GameObject[] mapPrefabs; // Prefab các map
    public Transform mapRoot;       // Nơi chứa map
    public int currentMapIndex = 0;

    private GameObject currentMapInstance;

    [Header("Config")]
    public bool autoLoadMap = true;

    // Tham chiếu Background Scroll
    private BackgroundScrollManager backgroundScroll;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (autoLoadMap)
        {
            LoadMap(currentMapIndex);
        }
    }

    public void LoadMap(int index)
    {
        if (index < 0 || index >= mapPrefabs.Length)
        {
            Debug.LogWarning("[MapManager] Invalid map index: " + index);
            return;
        }

        // Xóa map cũ nếu có
        if (currentMapInstance != null)
        {
            Destroy(currentMapInstance);
        }

        currentMapIndex = index;

        // Tạo map mới
        currentMapInstance = Instantiate(mapPrefabs[index], mapRoot.position, Quaternion.identity) as GameObject;
        currentMapInstance.transform.SetParent(mapRoot, true);

        Debug.Log("[MapManager] Loaded map: " + index);

        // Lấy BackgroundScrollManager từ map mới
        backgroundScroll = currentMapInstance.GetComponentInChildren<BackgroundScrollManager>();
        if (backgroundScroll != null)
        {
            backgroundScroll.ResumeScrolling(); // Bắt đầu scroll lại
            Debug.Log("[MapManager] BackgroundScrollManager attached for map " + index);
        }
        else
        {
            Debug.LogWarning("[MapManager] No BackgroundScrollManager found in map " + index);
        }

        // Gọi sự kiện khi map load xong
        if (OnMapLoaded != null)
        {
            OnMapLoaded(index);
        }

        // Khi map load xong, khởi động game (nếu cần)
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetGameState(GameState.Ready);
        }

        // Nếu autoStart đang bật, bắt đầu wave đầu tiên
        WaveManagerMonster waveMgr = FindObjectOfType(typeof(WaveManagerMonster)) as WaveManagerMonster;
        if (waveMgr != null && waveMgr.autoStart)
        {
            waveMgr.StartWave(0);
        }
    }

    public void ReloadCurrentMap()
    {
        LoadMap(currentMapIndex);
    }

    public void StopBackgroundScroll()
    {
        if (backgroundScroll != null)
            backgroundScroll.StopScrolling();
    }

    public void ResumeBackgroundScroll()
    {
        if (backgroundScroll != null)
            backgroundScroll.ResumeScrolling();
    }

    public void ChangeBackgroundToBoss(Material bossMaterial)
    {
        if (backgroundScroll != null)
            backgroundScroll.ChangeToBossBackground(bossMaterial);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.M))
        {
            ReloadCurrentMap();
        }
#endif
    }
}
