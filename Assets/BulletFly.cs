using UnityEngine;
public class BulletFly : MonoBehaviour
{
    public float speed = 20f; // Để đạn bay nhanh và to thì speed nên cao
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject, 3f); // Tự hủy sau 3s
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        { // Chỉ hủy khi chạm địch
            Destroy(gameObject);
        }
    }
}