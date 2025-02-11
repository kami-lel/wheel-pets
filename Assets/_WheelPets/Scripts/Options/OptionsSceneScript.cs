using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSceneScript : MonoBehaviour
{
    // todo connect more buttons, etc.

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void AdoptButtonOnClick()
    {
        SceneManager.LoadScene("AdoptionScene");
    }
}
