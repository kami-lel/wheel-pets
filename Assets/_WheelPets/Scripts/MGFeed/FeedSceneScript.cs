using UnityEngine;
using UnityEngine.SceneManagement;

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
