using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Kéo Prefab kẻ địch vào đây
    public float spawnInterval = 2f; // Cứ 2 giây sinh ra 1 con
    public float xRange = 2.5f;     // Khoảng ngẫu nhiên theo chiều ngang

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        // Tạo vị trí ngẫu nhiên ở phía trên màn hình
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(randomX, 6f, 0f);

        // Sinh ra kẻ địch từ Prefab
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}