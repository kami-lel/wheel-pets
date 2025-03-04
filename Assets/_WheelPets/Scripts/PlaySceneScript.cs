using UnityEngine;

// hack deprecation of play scene
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
