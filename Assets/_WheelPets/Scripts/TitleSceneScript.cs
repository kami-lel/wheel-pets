using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;

    [SerializeField]
    private GameObject leaderboardButton;

    [SerializeField]
    private GameObject closetButton;

    private void Start()
    {
        // disable some buttons in title screen if adoption hasnt happen
        bool adopted = Data.GetPlayerData().hasAdoptPet;
        playButton.SetActive(adopted);
        leaderboardButton.SetActive(adopted);
        closetButton.SetActive(adopted);
    }

    public void ClickPlayButton()
    {
        SceneChange.LoadSelector();
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

    public void ClickStoreButton()
    {
        SceneChange.LoadCloset();
    }

    public void ClickCreditsButton()
    {
        SceneChange.LoadCredits();
    }
}
