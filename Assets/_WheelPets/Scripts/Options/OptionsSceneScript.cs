using UnityEngine;
using UnityEngine.SceneManagement;

// BUG pet prefab is not properly rendered
// BUG should disallow change pet after first adopted it
// TODO option to re-adopt a new pet (accessory is kept though)
// TODO reset all data option
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
