using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static void LoadCloset()
    {
        SceneManager.LoadScene("ClosetScene");
    }

    public static void LoadDrivingGame()
    {
        SceneManager.LoadScene("DrivingGameScene");
    }

    public static void LoadLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public static void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public static void LoadPlayMenu()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public static void LoadSelector()
    {
        SceneManager.LoadScene("_SelectorScene");
    }

    public static void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public static void LoadBath()
    {
        SceneManager.LoadScene("BathScene");
    }

    public static void LoadFeed()
    {
        SceneManager.LoadScene("FeedScene");
    }

    public static void LoadFetch()
    {
        SceneManager.LoadScene("FetchScene");
    }

    public static void LoadHideAndSeek()
    {
        SceneManager.LoadScene("HideNSeekScene");
    }

    public static void LoadTOW()
    {
        SceneManager.LoadScene("TugOWarScene");
    }

    public static void LoadWalk()
    {
        SceneManager.LoadScene("WalkScene");
    }

    public static void LoadFeedInstructions()
    {
        SceneManager.LoadScene("FeedingInstructions");
    }

    public static void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    /// <summary>
    /// Manages the logic for exiting the adoption scene intelligently based on pet adoption status.
    /// </summary>
    /// <remarks>
    /// If a pet has never been adopted, which often occurs after a factor reset,
    /// exiting the adoption scene will navigate the user to the Driving Simulator.
    /// If a pet has already been adopted, exiting the adoption scene will navigate the user to the Options scene.
    /// </remarks>
    public static void LeaveAdoptionScene()
    {
        if (Data.GetPlayerData().hasAdoptPet)
        {
            LoadOptions();
        }
        else
        {
            LoadDrivingGame();
        }
    }
}
