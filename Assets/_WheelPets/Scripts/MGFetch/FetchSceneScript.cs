using UnityEngine;
using UnityEngine.SceneManagement;

// BUG replace static pet with PetPrebab
// todo add more instruction for how to play the game
// todo add high score function
// fixme common buttons: back, pause, etc. should share an uniform design language / placement across scenes
// FIXME use PauseOverlay to handle game start/pause/win/loss, remove GameOverPanel
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
