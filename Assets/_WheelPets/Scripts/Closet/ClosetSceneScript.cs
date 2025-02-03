using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosetSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
