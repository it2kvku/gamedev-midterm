using UnityEngine;
using TMPro; // dùng TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // singleton

    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    void Awake()
    {
        // đảm bảo chỉ có 1 instance tồn tại
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}