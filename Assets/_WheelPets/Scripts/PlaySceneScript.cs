using UnityEngine;
using UnityEngine.SceneManagement;

// BUG replace static pet with PetPrebab
public class PlaySceneScript : MonoBehaviour
{
    public void ClickLeaveButton()
    {
        SceneChange.LoadTitle();
    }

    public void ClickStoreButton()
    {
        SceneChange.LoadStore();
    }

    public void ClickClosetButton()
    {
        SceneChange.LoadCloset();
    }

    public void ClickMingamesButton()
    {
        SceneChange.LoadSelector();
    }

    public void ClickSettingsButton()
    {
        SceneChange.LoadOptions();
    }
}
