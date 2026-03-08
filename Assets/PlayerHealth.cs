using UnityEngine;

/// <summary>
/// Health của Player, kế thừa từ Health base class
/// </summary>
public class PlayerHealth : Health
{
    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Player nhận damage
    /// </summary>
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        // Có thể thêm hiệu ứng riêng cho player như:
        // - Rung camera
        // - Play sound hurt
        // - Flash màu đỏ
    }

    /// <summary>
    /// Player chết
    /// </summary>
    protected override void Die()
    {
        // Gọi base.Die() để tạo explosion và invoke event
        base.Die();
        
        // Có thể thêm logic riêng cho player khi chết
        Debug.Log("Player has died!");
    }
}
