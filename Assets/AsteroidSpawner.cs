using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] asteroidPrefabs;
    public float spawnRate = 2f;
    public float spawnDistance = 0.5f;
    public float asteroidSpeed = 8f;

    [Header("Target")]
    public Transform playerTransform;

    private float nextSpawnTime = 0f;

    void Start()
    {
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnAsteroid()
    {
        if (playerTransform == null) return;

        int index = Random.Range(0, asteroidPrefabs.Length);
        GameObject selectedPrefab = asteroidPrefabs[index];

        int side = Random.Range(0, 4);
        Vector2 spawnPos = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnPos = new Vector2(-spawnDistance, Random.Range(-5f, 5f));
                break;
            case 1:
                spawnPos = new Vector2(spawnDistance, Random.Range(-5f, 5f));
                break;
            case 2:
                spawnPos = new Vector2(Random.Range(-8f, 8f), spawnDistance);
                break;
            case 3:
                spawnPos = new Vector2(Random.Range(-8f, 8f), -spawnDistance);
                break;
        }

        GameObject asteroid = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        Vector2 directionToPlayer = (playerTransform.position - asteroid.transform.position).normalized;
        Vector2 randomOffset = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
        Vector2 finalDirection = (directionToPlayer + randomOffset).normalized;

        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = finalDirection * asteroidSpeed;
        }

        Destroy(asteroid, 15f);
    }
}
