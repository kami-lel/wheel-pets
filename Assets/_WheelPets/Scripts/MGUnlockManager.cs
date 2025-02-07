using System.Collections.Generic;
using UnityEngine;

public class MGUnlockManager : MonoBehaviour
{
    [SerializeField] public List<MGUnlock> MGUnlocks;
    public GameObject MGContainer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject MG in MGContainer.transform)
        {
            if (MG.tag == "Unlockable MG")
            {
                MGUnlocks.Add(new MGUnlock(MG));
            }
        }

        // sets the unlockable minigames to require 100 more points than the last
        for (int i = 0; i < MGUnlocks.Count; i++)
        {
            MGUnlocks[i].SetReq(100 + i);
            MGUnlocks[i].CheckPointReq();
        }
    }
}
