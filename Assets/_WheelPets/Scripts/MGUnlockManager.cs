using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MGUnlockManager : MonoBehaviour
{
    [SerializeField] public List<MGUnlock> MGUnlocks;
    public GameObject MGContainer; 
    private PlayerData playerData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerData = PlayerData.Data;

        foreach(Transform MG in MGContainer.transform)
        {
            if (MG.gameObject.tag == "Unlockable MG")
            {
                MGUnlocks.Add(new MGUnlock(MG.gameObject));
            }
        }

        // sets the unlockable minigames to require 100 more points than the last
        for (int i = 0; i < MGUnlocks.Count; i++)
        {
            MGUnlocks[i].SetReq(100 + i);
            MGUnlocks[i].CheckPointReq(playerData.gamePoint);
        }
    }
}
