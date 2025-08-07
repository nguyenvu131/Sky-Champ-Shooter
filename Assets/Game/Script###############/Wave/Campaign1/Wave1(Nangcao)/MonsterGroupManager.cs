using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGroupManager : MonoBehaviour
{
    public Formation formation;
    public GameObject monsterPrefab;

    private List<GameObject> members = new List<GameObject>();
    private GameObject leader;

    public void CreateGroup(Formation form, Vector3 center)
    {
        formation = form;
        members.Clear();

        for (int i = 0; i < form.offsets.Count; i++)
        {
            Vector3 spawnPos = center + form.offsets[i];
            GameObject m = Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
            members.Add(m);

            if (i == 0)
            {
                m.AddComponent<MonsterLeader>();
                leader = m;
            }
            else
            {
                MonsterFollower f = m.AddComponent<MonsterFollower>();
                f.SetLeader(leader.transform, form.offsets[i]);
            }
        }
    }
}