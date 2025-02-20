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
        SceneManager.LoadScene("FeedingInstructions");
    }

    public void BackGameButtonOnClick()
    {
        SceneManager.LoadScene("FeedScene");
    }
}
