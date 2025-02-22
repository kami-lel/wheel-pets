using UnityEngine;
using UnityEngine.SceneManagement;

// BUG pet prefab is not properly rendered
// BUG should disallow change pet after first adopted it
// TODO option to re-adopt a new pet (accessory is kept though)
// TODO reset all data option
public class OptionsSceneScript : MonoBehaviour
{
    // todo connect more buttons, etc. & combine w/ other code

    public void OnClickBackButon()
    {
        SceneChange.LoadTitle();
    }

    public void OnClickSaveButton()
    {
        // fixme is saving button even neccessary?
    }

    public void OnClickEnglishButton()
    {
        // todo connect with langauge manager
    }

    public void OnClickSpanishButton()
    {
        // todo connect with langauge manager
    }

    public void OnClickFrenchButton()
    {
        // todo connect with langauge manager
    }

    public void OnClickReAdoptButton()
    {
        // TODO
    }

    public void OnClickFactorResetButton()
    {
        // TODO
    }
}
