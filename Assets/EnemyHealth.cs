using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject explosionPrefab; // Ô để kéo hiệu ứng nổ vào

    // Hàm tự chạy khi có vật thể (đạn) đâm vào
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        // Tạo hiệu ứng nổ
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Xóa nổ sau 1 giây, xóa địch ngay lập tức
        Destroy(explosion, 1f);
        Destroy(gameObject);
    }
}