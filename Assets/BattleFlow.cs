using UnityEngine;

/// <summary>
/// Quản lý luồng trận chiến: Game Over, Game Win
/// </summary>
public class BattleFlow : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("UI hiển thị khi game over")]
    public GameObject gameOverUI;
    
    [Tooltip("UI hiển thị khi chiến thắng")]
    public GameObject gameWinUI;

    [Header("Game References")]
    [Tooltip("Tham chiếu đến PlayerHealth")]
    public PlayerHealth playerHealth;
    
    [Tooltip("Background music của game")]
    public GameObject bgMusic;

    private bool gameEnded = false;

    private void Start()
    {
        // Ẩn UI ban đầu
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
            
        if (gameWinUI != null)
            gameWinUI.SetActive(false);

        // Subscribe vào event onDead của player
        if (playerHealth != null)
        {
            playerHealth.onDead += OnGameOver;
        }
        else
        {
            Debug.LogWarning("PlayerHealth chưa được gán trong BattleFlow!");
        }
    }

    private void Update()
    {
        // Kiểm tra điều kiện thắng: hết enemy và game chưa kết thúc
        if (!gameEnded && EnemyHealth.LivingEnemyCount <= 0)
        {
            OnGameWin();
        }
    }

    /// <summary>
    /// Xử lý khi player chết - Game Over
    /// </summary>
    private void OnGameOver()
    {
        if (gameEnded) return;
        
        gameEnded = true;

        // Hiển thị UI Game Over
        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        // Tắt nhạc nền
        if (bgMusic != null)
            bgMusic.SetActive(false);

        Debug.Log("GAME OVER!");

        // Có thể thêm:
        // - Dừng game (Time.timeScale = 0)
        // - Play sound effect game over
        // - Lưu điểm số
    }

    /// <summary>
    /// Xử lý khi tiêu diệt hết enemy - Game Win
    /// </summary>
    private void OnGameWin()
    {
        if (gameEnded) return;
        
        gameEnded = true;

        // Hiển thị UI Game Win
        if (gameWinUI != null)
            gameWinUI.SetActive(true);

        // Tắt nhạc nền
        if (bgMusic != null)
            bgMusic.SetActive(false);

        // Vô hiệu hóa player
        if (playerHealth != null && playerHealth.gameObject != null)
            playerHealth.gameObject.SetActive(false);

        Debug.Log("GAME WIN! All enemies defeated!");

        // Có thể thêm:
        // - Play sound effect chiến thắng
        // - Hiệu ứng pháo hoa
        // - Tính điểm thưởng
    }

    /// <summary>
    /// Reset game để chơi lại
    /// </summary>
    public void RestartGame()
    {
        // Reset counter của enemy
        EnemyHealth.ResetCounter();
        
        // Reload scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    /// <summary>
    /// Quay về menu chính
    /// </summary>
    public void BackToMenu()
    {
        // Load scene menu (scene index 0)
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        // Unsubscribe event để tránh memory leak
        if (playerHealth != null)
        {
            playerHealth.onDead -= OnGameOver;
        }
    }
}
