using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // Di chuyển xuống dưới
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Nếu bay quá màn hình thì tự hủy cho nhẹ máy
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}