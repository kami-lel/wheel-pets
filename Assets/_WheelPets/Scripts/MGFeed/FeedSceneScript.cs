using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("_SelectorScene");
    }
}
