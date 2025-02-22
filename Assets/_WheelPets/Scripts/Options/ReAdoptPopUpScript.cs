using UnityEngine;

public class ReAdoptPopUpScript : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        // clear all data about the pet
        Data.GetPlayerData().petData = new();

        SceneChange.LoadAdoption();
    }

    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
