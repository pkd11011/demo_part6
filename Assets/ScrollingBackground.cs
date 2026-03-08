using UnityEngine;

/// <summary>
/// Tạo hiệu ứng background lướt vô hạn bằng cách scroll texture offset
/// Attach script này vào GameObject có Mesh Renderer
/// </summary>
public class ScrollingBackground : MonoBehaviour
{
    [Header("Background Settings")]
    [Tooltip("Renderer của background (Mesh Renderer hoặc Sprite Renderer)")]
    public Renderer bgRenderer;

    [Tooltip("Tốc độ cuộn background. Số dương = cuộn xuống, số âm = cuộn lên")]
    public float speed = 0.1f;

    [Header("Scroll Direction")]
    [Tooltip("Scroll theo trục X")]
    public bool scrollX = false;
    
    [Tooltip("Scroll theo trục Y")]
    public bool scrollY = true;

    private void Start()
    {
        // Tự động lấy Renderer nếu chưa gán
        if (bgRenderer == null)
        {
            bgRenderer = GetComponent<Renderer>();
            
            if (bgRenderer == null)
            {
                Debug.LogError("Không tìm thấy Renderer! Hãy gán bgRenderer hoặc thêm Renderer component.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bgRenderer == null || bgRenderer.material == null)
            return;

        // Tính toán offset mới dựa trên thời gian
        float offsetX = scrollX ? Time.time * speed : 0;
        float offsetY = scrollY ? Time.time * speed : 0;

        // Cập nhật material texture offset
        bgRenderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }

    /// <summary>
    /// Đặt tốc độ scroll mới
    /// </summary>
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    /// <summary>
    /// Dừng/Tiếp tục scroll
    /// </summary>
    public void SetScrolling(bool enabled)
    {
        this.enabled = enabled;
    }

    /// <summary>
    /// Reset offset về 0
    /// </summary>
    public void ResetOffset()
    {
        if (bgRenderer != null && bgRenderer.material != null)
        {
            bgRenderer.material.mainTextureOffset = Vector2.zero;
        }
    }
}
