using UnityEngine;
using UnityEngine.SceneManagement;

public class FetchSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }
}
