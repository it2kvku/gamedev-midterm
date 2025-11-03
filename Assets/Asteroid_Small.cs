using UnityEngine;

public class Asteroid_Small : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDestroyed = false;

    [Header("Movement")]
    public float moveSpeed = 3f;

    [Header("Rotation")]
    public float rotationSpeed = 50f;

    [Header("Scale")]
    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    private Transform playerTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Random scale ngẫu nhiên
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = Vector3.one * randomScale;

        // Tìm player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            // Di chuyển về phía player
            if (playerTransform != null)
            {
                Vector2 direction = (playerTransform.position - transform.position).normalized;
                rb.linearVelocity = direction * moveSpeed;
            }
        }
    }

    void Update()
    {
        // Xoay sprite
        if (!isDestroyed)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        // Kiểm tra nếu ra ngoài màn hình thì destroy
        CheckOutOfBounds();
    }

    void CheckOutOfBounds()
    {
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPos.x < -0.1f || screenPos.x > 1.1f ||
            screenPos.y < -0.1f || screenPos.y > 1.1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed) return;

        if (other.CompareTag("Bullet") || other.CompareTag("Player"))
        {
            TriggerExplosion();

            if (other.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }

    void TriggerExplosion()
    {
        isDestroyed = true;

        if (animator != null)
        {
            animator.SetTrigger("Explode");
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        ScoreManager.instance.AddScore(10);

        Destroy(gameObject, 1f);
    }
    
}
