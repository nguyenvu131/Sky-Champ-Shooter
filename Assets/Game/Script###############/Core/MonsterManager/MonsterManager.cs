using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;

    private List<GameObject> activeMonsters = new List<GameObject>();

    void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    /// <summary>
    /// Thêm quái vào danh sách
    /// </summary>
    public void RegisterMonster(GameObject monster)
    {
        if (!activeMonsters.Contains(monster))
            activeMonsters.Add(monster);
    }

    /// <summary>
    /// Xóa quái khỏi danh sách
    /// </summary>
    public void UnregisterMonster(GameObject monster)
    {
        if (activeMonsters.Contains(monster))
            activeMonsters.Remove(monster);
    }

    /// <summary>
    /// Lấy số lượng quái đang tồn tại
    /// </summary>
    public int GetActiveMonsterCount()
    {
        return activeMonsters.Count;
    }

    /// <summary>
    /// Xóa toàn bộ quái (ví dụ khi reset màn)
    /// </summary>
    public void ClearAllMonsters()
    {
        foreach (var monster in activeMonsters)
        {
            if (monster != null)
                Destroy(monster);
        }
        activeMonsters.Clear();
    }
}
