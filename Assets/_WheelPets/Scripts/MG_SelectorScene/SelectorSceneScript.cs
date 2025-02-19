using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGSelectorSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject MGButtons; // the group contains all minigame buttons

    private PlayerData playerData;
    private readonly List<MGUnlock> MGUnlocks = new();

    private void Start()
    {
        playerData = Data.GetPlayerData();
        // hack give player some point so mingame ares unlcoked
        playerData.drivingPoint = 1000;

        foreach (Transform child in MGButtons.transform)
        {
            MGUnlocks.Add(new MGUnlock(child.gameObject));
        }

        // sets the unlockable minigames to require 100 more points than the last
        // fixme use ParameterData for setting requirements
        for (int i = 0; i < MGUnlocks.Count; i++)
        {
            MGUnlocks[i].SetReq(100 + i);
            MGUnlocks[i].CheckPointReq(playerData.drivingPoint);
        }
    }

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void DogWalkButtonOnClick()
    {
        SceneManager.LoadScene("WalkScene");
    }

    public void DogBathButtonOnClick()
    {
        SceneManager.LoadScene("BathScene");
    }

    public void TugOWarButtonButtonOnClick()
    {
        SceneManager.LoadScene("TugOWarScene");
    }

    public void FetchButtonOnClick()
    {
        SceneManager.LoadScene("FetchScene");
    }

    public void HideNSeekButtonOnClick()
    {
        SceneManager.LoadScene("HideNSeekScene");
    }

    public void FeedButtonOnClick()
    {
        SceneManager.LoadScene("FeedScene");
    }
}
