using UnityEngine;

public class Asteroid_Big : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;

    private Animator animator;
    private Rigidbody2D rb;
    private bool isDestroyed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Random rotation direction
        if (rb != null)
        {
            rb.angularVelocity = Random.Range(-rotationSpeed, rotationSpeed);
        }
    }

    void Update()
    {
        if (!isDestroyed && rb == null)
        {
            // Fallback rotation if no Rigidbody2D
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed) return;

        // Check if hit by bullet or player
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

        // Stop movement
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0;
        }

        // Trigger explosion animation
        if (animator != null)
        {
            animator.SetTrigger("Explode");
        }

        // Destroy after animation
        Destroy(gameObject, 1f);
    }
}