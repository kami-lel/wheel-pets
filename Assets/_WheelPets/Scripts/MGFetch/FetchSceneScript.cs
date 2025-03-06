using UnityEngine;
using UnityEngine.SceneManagement;

// todo add more instruction for how to play the game
// BUG button not connected
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
