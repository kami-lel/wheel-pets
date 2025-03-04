using UnityEngine;

public class ResetDataPopUpScript : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        Data.ResetPlayerData();
        // disable the pop up
        gameObject.SetActive(false);
        SceneChange.LoadTitle();
    }

    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
