using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("--- DI CHUYỂN THEO CHUỘT ---")]
    public float moveSpeed = 15f;
    private Vector2 targetPosition;

    [Header("--- CHIẾN ĐẤU ---")]
    public GameObject projectilePrefab;
    public Transform centralGun;
    public float fireRate = 0.2f;
    private float nextFireTime;

    [Header("--- CHUỘT ---")]
    public float holdThreshold = 0.15f; // Thời gian phân biệt click / giữ
    private float mouseDownTime;
    private bool isHolding;

    void Update()
    {
        // Khi nhấn chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownTime = Time.time;
            isHolding = false;

            // BẮN 1 PHÁT NGAY (click)
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        // Khi đang giữ chuột trái
        if (Input.GetMouseButton(0))
        {
            // Nếu giữ đủ lâu -> chuyển sang chế độ giữ
            if (!isHolding && Time.time - mouseDownTime >= holdThreshold)
            {
                isHolding = true;
            }

            if (isHolding)
            {
                // DI CHUYỂN THEO CHUỘT
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition = new Vector2(mousePos.x, mousePos.y);
                transform.position = Vector2.Lerp(
                    transform.position,
                    targetPosition,
                    moveSpeed * Time.deltaTime
                );

                // BẮN LIÊN TỤC
                if (Time.time >= nextFireTime)
                {
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }

        // Khi nhả chuột
        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
        }
    }

    void Shoot()
    {
        if (projectilePrefab && centralGun)
        {
            Instantiate(projectilePrefab, centralGun.position, centralGun.rotation);
        }
    }
}
