using UnityEngine;

public class ResetDataPopUpScript : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        Data.ResetPlayerData();
        Data.GetPlayerData().hasAdoptPet = true;
        // disable the pop up
        gameObject.SetActive(false);
    }

    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
