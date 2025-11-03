using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifetime = 2f; // Thời gian sống của đạn (giây)
    public int damage = 1;      // Sát thương, tùy bạn dùng sau

    void Start() {
        Destroy(gameObject, lifetime); // Tự hủy sau 2 giây
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Nếu trúng  enemy
        if (other.CompareTag("Enemy")) {
          //  Destroy(other.gameObject); // Hủy mục tiêu
            Destroy(gameObject);       // Hủy đạn
        }
    }
}