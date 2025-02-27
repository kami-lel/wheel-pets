using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    private PlayerData playerData;

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

    void Start()
    {
        playerData = Data.GetPlayerData();

        // first time launch the game, must adopt the pet first
        if (!playerData.hasAdoptPet)
        {
            SceneChange.LoadAdoption();
        }
    }
}
