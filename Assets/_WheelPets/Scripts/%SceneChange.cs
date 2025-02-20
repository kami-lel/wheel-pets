using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static void LoadAdoption()
    {
        SceneManager.LoadScene("AdoptionScene");
    }

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

    public static void LoadStore()
    {
        SceneManager.LoadScene("StoreScene");
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
}

// fixme do not use this class, just use SceneManager.LoadScene
public class SceneSwapping : MonoBehaviour
{
    public AudioSource buttonClickSound;

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        PlayButtonClickSound();
        if (buttonClickSound != null)
        {
            yield return new WaitWhile(() => buttonClickSound.isPlaying);
        }
        SceneManager.LoadScene(sceneName);
    }

    // Load GameScene
    public void LoadDrivingGameScene()
    {
        StartCoroutine(LoadSceneWithDelay("DrivingGameScene"));
    }

    public void LoadPetGameScene()
    {
        StartCoroutine(LoadSceneWithDelay("PetGameScene"));
    }

    public void LoadTitleScene()
    {
        StartCoroutine(LoadSceneWithDelay("TitleScene"));
    }

    public void LoadLeaderboardScene()
    {
        StartCoroutine(LoadSceneWithDelay("LeaderboardScene"));
    }

    public void LoadOptionsScene()
    {
        StartCoroutine(LoadSceneWithDelay("OptionsScene"));
    }

    public void LoadClosetScene()
    {
        StartCoroutine(LoadSceneWithDelay("ClosetScene"));
    }

    public void LoadMinigameSelectorSecene()
    {
        StartCoroutine(LoadSceneWithDelay("_SelectorScene"));
    }

    public void LoadDogCareScene()
    {
        StartCoroutine(LoadSceneWithDelay("DogWalkScene"));
    }

    public void LoadDogBathScene()
    {
        StartCoroutine(LoadSceneWithDelay("DogBathScene"));
    }

    public void LoadTugOfWarScene()
    {
        StartCoroutine(LoadSceneWithDelay("Tug-o-WarScene"));
    }

    public void LoadFetchScene()
    {
        StartCoroutine(LoadSceneWithDelay("FetchScene"));
    }

    public void ExitGame()
    {
        PlayButtonClickSound();
        StartCoroutine(ExitGameWithDelay());
    }

    private IEnumerator ExitGameWithDelay()
    {
        if (buttonClickSound != null)
        {
            yield return new WaitWhile(() => buttonClickSound.isPlaying);
        }
        Application.Quit();
    }
}


//  public class SceneSwapping : MonoBehaviour
//  {
//     //Load GameScene
//     public void LoadDrivingGameScene()
//     {
//         SceneManager.LoadScene("DrivingGameScene");
//     }
//
//      public void LoadPetGameScene()
//     {
//         SceneManager.LoadScene("PetGameScene");
//     }
//
//     public void LoadTitleScene()
//     {
//         SceneManager.LoadScene("TitleScene");
//     }
//
//     public void LoadLeaderboardScene()
//     {
//         SceneManager.LoadScene("LeaderboardScene");
//     }
//
//     public void LoadOptionsScene(){
//           SceneManager.LoadScene("OptionsScene");
//     }
//
//     public void LoadDogCareScene()
//     {
//          SceneManager.LoadScene("DogWalkScene");
//     }
//
//     public void LoadClosetScene()
//     {
//      SceneManager.LoadScene("ClosetScene");
//     }
//
//     public void ExitGame(){
//          Application.Quit();
//     }
//
//
//
//  }
//
