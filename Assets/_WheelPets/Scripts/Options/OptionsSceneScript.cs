using UnityEngine;
using UnityEngine.SceneManagement;

// bug pet prefab is not properly rendered
public class OptionsSceneScript : MonoBehaviour
{
    // todo connect more buttons, etc.

    public void BackButtonOnClick()
    {
        SceneChange.LoadTitle();
    }

    public void AdoptButtonOnClick()
    {
        SceneChange.LoadAdoption();
    }
}
