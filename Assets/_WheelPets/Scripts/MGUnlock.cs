using UnityEngine;
[System.Serializable]
public class MGUnlock
{
    public GameObject button;
    public int req;

    public MGUnlock(GameObject button, int req)
    {
        this.button = button;
        this.req = req;
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
}
