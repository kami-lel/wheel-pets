using UnityEngine;
using UnityEngine.SceneManagement;

// BUG replace static pet with PetPrebab
// fixme Confusion on how to play because there were no numbers
// BUG Feeding the correct food would cause it to break
// todo add more instruction for how to play the game
// todo add high score function
// fixme common buttons: back, pause, etc. should share an uniform design language / placement across scenes
// FIXME use PauseOverlay to handle game start/pause/win/loss, remove GameOverPanel
public class FeedSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    public void InfoButtonOnClick()
    {
        SceneChange.LoadFeedInstructions();
    }

    public void BackGameButtonOnClick()
    {
        SceneChange.LoadFeed();
    }
}
