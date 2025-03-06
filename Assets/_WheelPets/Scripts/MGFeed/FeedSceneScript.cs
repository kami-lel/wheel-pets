using UnityEngine;
using UnityEngine.SceneManagement;

// fixme Confusion on how to play because there were no numbers
// todo add more instruction for how to play the game
// bug instruction button not working
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
