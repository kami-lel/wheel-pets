using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPrefab;
    private GameObject gameOverInstance;
    public GameObject panelObject;

    void Start()
    {
        // create prefab if it doesn't exist
        if (gameOverInstance == null)
        {
            gameOverInstance = Instantiate(
                gameOverPrefab,
                parent: panelObject.transform
            );
            gameOverInstance.SetActive(false);
        }
    }

    public void ShowGameOver()
    {
        gameOverInstance.SetActive(true);
        Time.timeScale = 0f;
    }
}
