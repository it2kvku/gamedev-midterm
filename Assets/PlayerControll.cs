using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControll : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    [Header("Shooting Settings")]
    [FormerlySerializedAs("Bulletspeed")] 
    public float Bullet_speed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f; // Thời gian chờ giữa các lần bắn
    public AudioClip ShootSound; 
    
    private float nextFireTime = 0f;
    private Camera mainCamera;
    private AudioSource audioSource;

    void Start()
    {
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>(); // ✅ Lấy AudioSource gán cho Player
    }
    void Update()
    {
        HandleRotation();
        HandleMovement();
        HandleShooting();
    }
    void HandleRotation()
    {
        // Lấy vị trí chuột trong world space
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Đảm bảo z = 0 cho 2D

        // Tính hướng từ ship đến chuột
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Tính góc xoay
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Xoay ship (trừ 90 độ nếu sprite mặc định hướng lên)
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
    void HandleMovement()
    {
        if (Input.GetMouseButton(0)) // Click trái để di chuyển
        {
            // Di chuyển theo hướng ship đang quay (transform.up)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        }
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.W) && Time.time >= nextFireTime)
        {
            Shoot();
            
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = firePoint.up * Bullet_speed;
            }

            audioSource.PlayOneShot(ShootSound); // ✅ phát âm thanh bắn từ Player
        }
    }

}