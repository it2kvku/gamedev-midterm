using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject instructionsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // thay tên scene gameplay của bạn
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}