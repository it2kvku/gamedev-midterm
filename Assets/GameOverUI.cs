using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        if (scoreText != null)
            scoreText.text = "SCORE: " + finalScore;
        else
            Debug.LogWarning("⚠️ ScoreText is missing!");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}