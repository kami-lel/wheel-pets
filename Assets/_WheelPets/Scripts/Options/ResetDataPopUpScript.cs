using UnityEngine;

public class ResetDataPopUpScript : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        Data.ResetPlayerData();
        SceneChange.LoadAdoption();
    }

    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
