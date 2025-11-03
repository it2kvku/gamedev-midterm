using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxLives = 3;
    private int currentLives;

    [Header("UI Hearts")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int amount)
    {
        currentLives -= amount;
        if (currentLives < 0) currentLives = 0;

        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    void GameOver()
    {
        Debug.Log("💀 GAME OVER!");
        PlayerPrefs.SetInt("FinalScore", ScoreManager.instance.GetScore());
        SceneManager.LoadScene("GameOver"); // đổi tên scene nếu khác
    }
}