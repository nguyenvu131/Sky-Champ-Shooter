using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletLeft : MonoBehaviour {

	public float damage = 10f; // Sát thương mặc định của đạn (có thể không dùng nếu dùng DamageInfo)
    public float lifeTime = 3f; // Thời gian sống tối đa của đạn (tính từ lúc spawn)
    private float timer; // Bộ đếm thời gian còn lại trước khi đạn bị hủy
	public int baseDamage; // Sát thương cơ bản của viên đạn
	public MonsterStats attackerStats; // Chỉ số tấn công của pet hoặc quái bắn ra đạn này

    void OnEnable()
    {
        timer = lifeTime; // Mỗi lần đạn được kích hoạt (spawn), reset thời gian tồn tại
    }

    void Update()
    {
        timer -= Time.deltaTime; // Giảm thời gian mỗi frame
        if (timer <= 0f) // Nếu hết thời gian
        {
            PlayerBulletPoolManager.Instance.ReturnToPool(gameObject); // Trả viên đạn về pool để tái sử dụng
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Xử lý khi đạn va chạm với collider khác
    {
        if (other.CompareTag("Enemy")) // Kiểm tra xem collider đó có phải quái không
        {
            Monster monster = other.GetComponent<Monster>(); // Lấy script Monster từ enemy
            if (monster != null) // Nếu có tồn tại
            {
                float targetDefense = monster.stats.def; // Lấy chỉ số phòng thủ của quái
				DamageInfo info = new DamageInfo(baseDamage, attackerStats.atk); // Tạo DamageInfo với sát thương cơ bản + tấn công người bắn
				float damage = DamageCalculator.CalculateDamage(info, targetDefense); // Tính sát thương cuối cùng theo công thức
				monster.TakeDamage(damage); // Gây sát thương cho quái
            }

            PlayerBulletPoolManager.Instance.ReturnToPool(gameObject); // Sau khi va chạm, trả đạn về pool
        }
    }
}
