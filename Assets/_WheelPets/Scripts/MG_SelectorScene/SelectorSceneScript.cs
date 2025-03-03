using System.Collections.Generic;
using UnityEngine;

public class MGSelectorSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject MGButtons; // the group contains all minigame buttons

    private PlayerData playerData;
    private readonly List<MGUnlock> MGUnlocks = new();

    private void Start()
    {
        playerData = Data.GetPlayerData();
        // HACK give player some point so mingame ares unlcoked
        playerData.drivingPoint = 1000;

        foreach (Transform child in MGButtons.transform)
        {
            MGUnlocks.Add(new MGUnlock(child.gameObject));
        }

        // sets the unlockable minigames to require 100 more points than the last
        for (int i = 0; i < MGUnlocks.Count; i++)
        {
            MGUnlocks[i].SetReq(100 + i);
            MGUnlocks[i].CheckPointReq(playerData.drivingPoint);
        }
    }

    public void BackButtonOnClick()
    {
        SceneChange.LoadTitle();
    }

    public void DogWalkButtonOnClick()
    {
        SceneChange.LoadWalk();
    }

    public void DogBathButtonOnClick()
    {
        SceneChange.LoadBath();
    }

    public void TugOWarButtonButtonOnClick()
    {
        SceneChange.LoadTOW();
    }

    public void FetchButtonOnClick()
    {
        SceneChange.LoadFetch();
    }

    public void HideNSeekButtonOnClick()
    {
        SceneChange.LoadHideAndSeek();
    }

    public void FeedButtonOnClick()
    {
        SceneChange.LoadFeed();
    }
}
