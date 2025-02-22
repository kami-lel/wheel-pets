using UnityEngine;

public class ResetDataPopUpScript : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        Data.ResetPlayerData();
    }

    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
