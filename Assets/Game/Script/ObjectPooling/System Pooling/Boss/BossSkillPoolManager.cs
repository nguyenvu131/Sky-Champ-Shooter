using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	//huong dan su dung
	// Vector3 pos = transform.position;
    // Quaternion rot = transform.rotation;

    // var skill = BossSkillPoolManager.Instance.GetSkill(BossSkillType.Laser, pos, rot);

public class BossSkillPoolManager : MonoBehaviour
{
   public static BossSkillPoolManager Instance;

    [System.Serializable]
    public class SkillPool
    {
        public BossSkillType type;
        public GameObject prefab;
        public int initialSize = 5;
    }

    public List<SkillPool> skillPools;

    private Dictionary<BossSkillType, Queue<IBossSkill>> poolDictionary = new Dictionary<BossSkillType, Queue<IBossSkill>>();

    void Awake()
    {
        Instance = this;

        foreach (var pool in skillPools)
        {
            var queue = new Queue<IBossSkill>();
            for (int i = 0; i < pool.initialSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                queue.Enqueue(obj.GetComponent<IBossSkill>());
            }
            poolDictionary.Add(pool.type, queue);
        }
    }

    public IBossSkill GetSkill(BossSkillType type, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(type)) return null;

        IBossSkill skill;
        if (poolDictionary[type].Count > 0)
        {
            skill = poolDictionary[type].Dequeue();
        }
        else
        {
            GameObject prefab = skillPools.Find(p => p.type == type).prefab;
            GameObject obj = Instantiate(prefab);
            skill = obj.GetComponent<IBossSkill>();
        }

        skill.Activate(position, rotation);
        return skill;
    }

    public void ReturnSkill(BossSkillType type, IBossSkill skill)
    {
        skill.Deactivate();
        poolDictionary[type].Enqueue(skill);
    }
}
