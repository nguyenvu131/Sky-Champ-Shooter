using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignSpawner : MonoBehaviour {

	public MonsterGroupManager groupManagerPrefab;
    public GameObject monsterPrefab;

    public void SpawnGroupFormation(Vector3 center)
    {
        var group = Instantiate(groupManagerPrefab);
        group.monsterPrefab = monsterPrefab;
        group.CreateGroup(Formation.VShape(), center);
    }
}
