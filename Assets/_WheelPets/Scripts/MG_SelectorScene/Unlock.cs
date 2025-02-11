using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MGUnlock
{
    public GameObject button;
    public int req;

    public MGUnlock(GameObject button)
    {
        this.button = button;
        this.req = 0;
    }

    public void CheckPointReq(int score)
    {
        if (score >= this.req)
        {
            this.button.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.button.GetComponent<Button>().interactable = false;
        }
    }

    public void SetReq(int req)
    {
        this.req = req;
    }
}
