using UnityEngine;

public class ResetDataPopUpScript : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        // BUG reset data function is broken
        Data.ResetPlayerData();
        SceneChange.LoadOptions(); // re-launcch current scene
    }

    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
