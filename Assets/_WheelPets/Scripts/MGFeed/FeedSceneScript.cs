using UnityEngine;
using UnityEngine.SceneManagement;

// bug replace static pet with PetPrebab
// fixme Confusion on how to play because there were no numbers
// bug Feeding the correct food would cause it to break
// todo add start button
// todo add more instruction for how to play the game
// todo add high score function
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
