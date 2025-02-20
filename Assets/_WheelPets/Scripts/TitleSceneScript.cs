using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    public void ClickPlayButton()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void ClickOptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void ClickLeaderboardButton()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void ClickExitButton()
    {
        // fixme use scene changer
        SceneManager.LoadScene("DrivingGameScene");
    }
}
