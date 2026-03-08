using UnityEngine;

/// <summary>
/// Enemy Health kế thừa từ Health base class
/// Có chức năng đếm số enemy còn sống
/// </summary>
public class EnemyHealth : Health
{
    /// <summary>
    /// Đếm số lượng enemy còn sống trong game
    /// </summary>
    public static int LivingEnemyCount = 0;

    // Khi enemy được spawn, tăng counter
    private void Awake()
    {
        LivingEnemyCount++;
    }

    // Hàm tự chạy khi có vật thể (đạn) đâm vào
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra có phải đạn của player không
        if (collision.CompareTag("Projectile") || collision.CompareTag("PlayerBullet"))
        {
            Die();
        }
    }

    /// <summary>
    /// Override Die để giảm counter khi enemy chết
    /// </summary>
    protected override void Die()
    {
        // Giảm số lượng enemy còn sống
        LivingEnemyCount--;
        
        // Gọi base.Die() để xử lý explosion và destroy
        base.Die();
        
        Debug.Log($"Enemy died! Remaining enemies: {LivingEnemyCount}");
    }

    /// <summary>
    /// Reset counter khi bắt đầu level mới
    /// </summary>
    public static void ResetCounter()
    {
        LivingEnemyCount = 0;
    }
}