using UnityEngine;
using UnityEngine.SceneManagement;

// TODO add more instruction for how to play the game
// TODO add high score function
public class FetchSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    public void PlayAgainButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
