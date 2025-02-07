using UnityEngine;
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
            this.button.SetActive(true);
        } else {
            this.button.SetActive(false);
        }
    }

    public void SetReq(int req)
    {
        this.req = req;
    }
}
