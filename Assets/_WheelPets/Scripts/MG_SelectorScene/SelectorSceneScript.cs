using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGSelectorSceneScript : MonoBehaviour
{
    public List<MGUnlock> MGUnlocks;
    public GameObject MGContainer;
    private PlayerData playerData;

    private void Start()
    {
        playerData = PlayerData.Data;

        foreach (Transform MG in MGContainer.transform)
        {
            if (MG.gameObject.tag == "Unlockable MG")
            {
                MGUnlocks.Add(new MGUnlock(MG.gameObject));
            }
        }

        // sets the unlockable minigames to require 100 more points than the last
        // TODO use game parameters
        for (int i = 0; i < MGUnlocks.Count; i++)
        {
            MGUnlocks[i].SetReq(100 + i);
            MGUnlocks[i].CheckPointReq(playerData.gamePoint);
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
