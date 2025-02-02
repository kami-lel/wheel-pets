using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPrefab;
    private GameObject gameOverInstance;   
    void Start()
    {
        // create prefab if it doesn't exist
        if (gameOverInstance == null)
        {
            gameOverInstance = Instantiate(gameOverPrefab);
            gameOverInstance.SetActive(false);
        }
    }

    public void ShowGameOver()
    {
        gameOverInstance.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("_SelectorScene");
    }
}
