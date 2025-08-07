using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerSpawner : MonoBehaviour {

	public int numberOfFollowers = 3;
	public Vector3[] offsetList;

	void Start()
	{
		for (int i = 0; i < numberOfFollowers; i++)
		{
			GameObject follower = AIFollowerPool.Instance.GetFollower();
			AI_Follower ai = follower.GetComponent<AI_Follower>();
			Vector3 offset = (i < offsetList.Length) ? offsetList[i] : new Vector3(1.5f * i, 0, 0);
			ai.Init(transform, offset);
		}
	}
}
