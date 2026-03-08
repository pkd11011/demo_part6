using UnityEngine;

public class EngineEffect : MonoBehaviour
{
    [Header("Cấu hình nhấp nháy")]
    public float flickerSpeed = 20f;  // Tốc độ nhấp nháy
    public float minScale = 0.9f;    // Kích thước nhỏ nhất
    public float maxScale = 1.2f;    // Kích thước lớn nhất

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // 1. Tạo hiệu ứng co giãn (Scale) ngẫu nhiên để giống ngọn lửa đang cháy
        float scaleOffset = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(originalScale.x * scaleOffset, originalScale.y * scaleOffset, originalScale.z);

        // 2. Tạo hiệu ứng mờ ảo (Alpha) nhấp nháy nhẹ
        if (spriteRenderer != null)
        {
            float alpha = Random.Range(0.7f, 1.0f);
            Color newColor = spriteRenderer.color;
            newColor.a = alpha;
            spriteRenderer.color = newColor;
        }
    }
}