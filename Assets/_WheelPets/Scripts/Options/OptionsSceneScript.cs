using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.LogWarning("save button pushed, no effect yet");
    }

    public void OnClickEnglishButton()
    {
        // todo connect with langauge manager
        Debug.LogWarning("language->English, no effect yet");
    }

    public void OnClickSpanishButton()
    {
        // todo connect with langauge manager
        Debug.LogWarning("language->Spanish, no effect yet");
    }

    public void OnClickFrenchButton()
    {
        // todo connect with langauge manager
        Debug.LogWarning("language->French, no effect yet");
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
