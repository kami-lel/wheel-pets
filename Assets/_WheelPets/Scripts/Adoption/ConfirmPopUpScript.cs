using TMPro;
using UnityEngine;

// fixme improve ui placement & design
public class ConfirmPopUpScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField petNameField;

    private PlayerData playerData;

    private void Start()
    {
        playerData = Data.GetPlayerData();
    }

    public void ConfirmButtonOnClick()
    {
        if (petNameField.text != "")
        {
            playerData.petData.name = petNameField.text;
        }

        playerData.hasAdoptPet = true;
        SceneChange.LeaveAdoptionScene();
    }

    public void CancelButtonOnClick()
    {
        // Disable this game object by setting active to false
        gameObject.SetActive(false);
    }
}
