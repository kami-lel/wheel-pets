using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSceneScript : MonoBehaviour
{
    // TODO connect more buttons, etc.

    public void ClickBackButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
