using UnityEngine;
using UnityEngine.SceneManagement;

// BUG replace static pet with PetPrebab
// TODO make store functional w/ placeholder pictures
public class StoreSceneScript : MonoBehaviour
{
    public void ClosetButtonOnClick()
    {
        SceneChange.LoadCloset();
    }

    public void SettingsButtonOnClick()
    {
        SceneChange.LoadOptions();
    }

    public void MinigameButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    public void LeaveButtonOnClick()
    {
        SceneChange.LoadPlayMenu();
    }
}
