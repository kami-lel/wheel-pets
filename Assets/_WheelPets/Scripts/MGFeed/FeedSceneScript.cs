using UnityEngine;
using UnityEngine.SceneManagement;

// FIXME Confusion on how to play because there were no numbers
// TODO add more instruction for how to play the game
// TODO add high score function
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
