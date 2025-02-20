using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    public void ClickPlayButton()
    {
        SceneChange.LoadPlayMenu();
    }

    public void ClickOptionsButton()
    {
        SceneChange.LoadOptions();
    }

    public void ClickLeaderboardButton()
    {
        SceneChange.LoadLeaderboard();
    }

    public void ClickExitButton()
    {
        SceneChange.LoadDrivingGame();
    }
}
