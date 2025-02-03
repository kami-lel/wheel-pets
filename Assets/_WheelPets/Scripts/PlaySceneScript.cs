using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneScript : MonoBehaviour
{
    public void ClickLeaveButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ClickStoreButton()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void ClickClosetButton()
    {
        SceneManager.LoadScene("ClosetScene");
    }

    public void ClickMingamesButton()
    {
        SceneManager.LoadScene("_SelectorScene");
    }

    public void ClickSettingsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }
}
