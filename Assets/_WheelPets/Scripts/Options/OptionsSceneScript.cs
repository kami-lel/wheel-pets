using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSceneScript : MonoBehaviour
{
    // TODO connect more buttons, etc.

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void AdoptButtonOnClick()
    {
        SceneManager.LoadScene("AdoptionScene");
    }
}
