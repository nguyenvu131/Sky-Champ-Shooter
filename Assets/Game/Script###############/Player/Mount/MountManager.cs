using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountManager : MonoBehaviour
{
    public Mount currentMount;
    public MountData equippedMountData;
	public PlayerStats playerStats; 

    public Transform mountHolder;

    void Start()
    {
        EquipMount(equippedMountData);
    }

    public void EquipMount(MountData mountData)
    {
        if (currentMount != null)
            Destroy(currentMount.gameObject);

        GameObject obj = Instantiate(mountData.mountPrefab, mountHolder.position, Quaternion.identity);
        obj.transform.SetParent(mountHolder);

        currentMount = obj.GetComponent<Mount>();
        currentMount.data = mountData;

        ApplyMountBonus(mountData);
    }

    void ApplyMountBonus(MountData data)
    {
        if (PlayerStats.Instance != null)
		{
			PlayerStats.Instance.AddBonusStats(
				data.bonusHP, data.bonusAttack, data.bonusDefense, data.bonusSpeed);
		}
    }

    public void TriggerMountSkill()
    {
        if (currentMount != null)
        {
            currentMount.ActivateSkill();
        }
    }
}