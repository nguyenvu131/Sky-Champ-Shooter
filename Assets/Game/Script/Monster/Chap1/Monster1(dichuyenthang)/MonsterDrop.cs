using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDrop : MonoBehaviour {

	public GameObject[] dropItems;

	public DropItem[] dropList;
	public float dropRadius = 0.5f; // bán kính ngẫu nhiên xung quanh


	public void Drop()
	{
		foreach (DropItem item in dropList)
		{
			float roll = Random.Range(0f, 100f);
			if (roll <= item.dropRate)
			{
				for (int i = 0; i < item.amount; i++)
				{
					Vector3 dropPos = transform.position + (Vector3)(Random.insideUnitCircle * dropRadius);

					// Nếu dùng pooling:
					// ObjectPooler.Instance.Spawn(item.prefab.name, dropPos, Quaternion.identity);

					// Nếu không dùng pooling:
//					Instantiate(item.prefab, dropPos, Quaternion.identity);

					ObjectPooler.Instance.Spawn("Coin", dropPos, Quaternion.identity);
					ObjectPooler.Instance.Spawn(item.prefab.name, dropPos, Quaternion.identity);

				}
			}
		}
	}
		
	public void SpawnDrop()
	{
		if (dropItems == null || dropItems.Length == 0) return;

		// Random 1 item
		int index = Random.Range(0, dropItems.Length);
		GameObject item = Instantiate(dropItems[index], transform.position, Quaternion.identity);
		item.transform.SetParent(this.transform); // hoặc add force, set layer...
	}
}
