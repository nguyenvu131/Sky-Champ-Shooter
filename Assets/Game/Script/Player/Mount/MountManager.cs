using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountManager : MonoBehaviour {

	public Transform mountSpawnPoint;
	public MountData equippedMount;
	private GameObject activeMount;

	void Start()
	{
		if (equippedMount != null)
			EquipMount(equippedMount);
		
	}

	public void EquipMount(MountData data)
	{
		if (activeMount != null)
			Destroy(activeMount);

		activeMount = Instantiate(data.mountPrefab, mountSpawnPoint.position, Quaternion.identity, transform);
		MountController mc = activeMount.GetComponent<MountController>();
		mc.Initialize(data);
	}
}
