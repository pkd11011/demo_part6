using UnityEngine;
using System;

/// <summary>
/// Base class cho health system với event onDead
/// </summary>
public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("Prefab hiệu ứng nổ khi chết")]
    public GameObject explosionPrefab;

    [Tooltip("Máu mặc định")]
    public int defaultHealthPoint;

    [Header("Events")]
    [Tooltip("Event được gọi khi đối tượng chết")]
    public Action onDead;

    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = defaultHealthPoint;
    }

    /// <summary>
    /// Nhận damage
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Xử lý khi chết
    /// </summary>
    protected virtual void Die()
    {
        // Tạo hiệu ứng nổ
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1f);
        }

        // Invoke event onDead
        onDead?.Invoke();

        // Hủy game object
        Destroy(gameObject);
    }

    /// <summary>
    /// Heal máu
    /// </summary>
    public virtual void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, defaultHealthPoint);
    }

    /// <summary>
    /// Kiểm tra còn sống hay không
    /// </summary>
    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    /// <summary>
    /// Get current health
    /// </summary>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
