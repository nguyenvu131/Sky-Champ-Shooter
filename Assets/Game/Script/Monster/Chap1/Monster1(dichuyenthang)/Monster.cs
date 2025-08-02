using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour 
{
	
	public MonsterStats stats; // sẽ hiển thị đầy đủ trong Inspector
	
	public GameObject uiPrefab;             // Prefab giao diện UI (thanh máu, level) hiển thị trên đầu quái
	public GameObject uiInstance;           // Instance của UI đã được tạo ra khi quái spawn

	public Text textLevel;                  // Text hiển thị level của quái (ví dụ: "Lv.5")
	public Text textHP;                     // Text hiển thị máu hiện tại hoặc phần trăm máu

	public PopupDamageSpawner popupSpawner; // Script quản lý việc spawn popup sát thương khi bị bắn

	public int level = 1;                   // Level mặc định của quái, ảnh hưởng đến chỉ số cơ bản
	public int monsterLevel = 1;            // Có thể dùng để phân biệt hoặc hiển thị riêng trong UI

	public float currentHP;                 // Lượng máu hiện tại của quái, bị trừ khi nhận sát thương
	public float moveSpeed;                 // Tốc độ di chuyển của quái, điều chỉnh để tạo độ khó
	public float damage;                    // Sát thương quái gây ra cho người chơi khi tấn công hoặc va chạm
	public float attackDelay;               // Thời gian giữa các lần tấn công, ví dụ: bắn đạn mỗi 2 giây
	
	public string dropType = "Coin"; // có thể là "Gem", "Item"
	
	void Start()
    {	
		
        stats.currentHP = stats.maxHP;
		
		CreateUI();
		UpdateUI();
        
		// Nếu chưa gán thủ công trong Inspector, tự tìm trong scene
        if (popupSpawner == null)
        {
            popupSpawner = FindObjectOfType<PopupDamageSpawner>();
        }
		stats = new MonsterStats(monsterLevel);
        // Áp dụng stats cho monster
        currentHP = stats.hp;
        moveSpeed = stats.moveSpeed;
        attackDelay = stats.attackSpeed;
        damage = stats.damage;

        // Hiển thị chỉ số hoặc debug
        Debug.Log("Monster Lv" + level + " | HP: " + stats.hp + " | DMG: " + stats.damage);
		
    }

    public void TakeDamage(float damage)
    {
        float finalDamage = damage - stats.defense;
        finalDamage = Mathf.Max(finalDamage, 1);

        stats.currentHP -= finalDamage;
		
		// Gọi popup text
		// Vector3 popupPos = uiFollowPoint.position + new Vector3(0, 1f, 0); // trên đầu quái
		// PopupTextPoolManager.Instance.SpawnPopup("damage", popupPos, "-" + damage);
        
		//
		// FindObjectOfType<PowerUpSpawner>().TrySpawnPowerUp(transform.position);
		
		// GỌI POPUP DAMAGE tại vị trí quái
        if (popupSpawner != null)
        {
           FindObjectOfType<PopupDamageSpawner>().ShowDamage((int)damage, this.transform);
        }
		
		//
		UpdateUI();
		UpdateEffect();
		
        if (stats.currentHP <= 0 || stats.hp <= 0)
		{
			Die();
		}
    }

    void Die()
    {
		//
		Vector3 effectPos = transform.position;
		EffectPoolManager.Instance.SpawnEffect("explosion", effectPos, Quaternion.identity);
		//
		DropItemPoolManager.Instance.SpawnItem("Coin", transform.position);
      //  Destroy(gameObject); // hoặc gameObject.SetActive(false) nếu dùng pooling quái
        Monster5DirectionShooter shooter = GetComponent<Monster5DirectionShooter>();
        if (shooter != null)
        {
            shooter.OnDeath();
        }
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject, 0.5f);
    }
	
	void UpdateUI()
    {
		
        if (textLevel != null)
            textLevel.text = "Lv. " + stats.level;

        if (textHP != null)
            textHP.text = stats.currentHP + " / " + stats.maxHP;
    }
	
	void CreateUI()
    {
        if (uiPrefab == null)
            uiPrefab = Resources.Load<GameObject>("UI/UI_MonsterInfo");

        // Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // uiInstance = Instantiate(uiPrefab, canvas.transform);

        // Set follow target
        // MonsterUIFollow follow = uiInstance.GetComponent<MonsterUIFollow>();
        // follow.target = this.transform;

        // Get text references
        // textLevel = uiInstance.transform.Find("Text_Level").GetComponent<Text>();
        // textHP = uiInstance.transform.Find("Text_HP").GetComponent<Text>();
    }
	
	void UpdateEffect()
	{
		// Hiệu ứng trúng đòn
		Vector3 hitPos = transform.position;
		EffectPoolManager.Instance.SpawnEffect("hit", hitPos, Quaternion.identity);
	}
	
	void OnDestroy()
    {
        if (uiInstance != null)
            Destroy(uiInstance);
    }
}
