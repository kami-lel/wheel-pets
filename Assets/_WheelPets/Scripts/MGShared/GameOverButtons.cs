using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour
{
    public Button restartButton;
    public Button returnButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        returnButton.onClick.AddListener(ReturnToMenu);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneChange.LoadSelector();
    }
}
