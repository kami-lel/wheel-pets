using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject reAdoptPopUp;

    [SerializeField]
    private GameObject resetDataPopUp;

    // todo connect more buttons, etc. & combine w/ other code

    public void OnClickBackButon()
    {
        SceneChange.LoadTitle();
    }

    public void OnClickSaveButton()
    {
        // Fixme is saving button even neccessary?
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
        reAdoptPopUp.SetActive(true);
    }

    public void OnClickFactorResetButton()
    {
        resetDataPopUp.SetActive(true);
    }
}
