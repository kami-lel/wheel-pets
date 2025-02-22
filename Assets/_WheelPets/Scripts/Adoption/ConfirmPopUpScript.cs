using TMPro;
using UnityEngine;

// fixme improve ui placement & design
public class ConfirmPopUpScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField petNameField;

    public void ConfirmButtonOnClick()
    {
        // TODO
        if (petNameField.text != "")
        {
            Data.GetPlayerData().petData.name = petNameField.text;
        }
    }

    public void CancelButtonOnClick()
    {
        // Disable this game object by setting active to false
        gameObject.SetActive(false);
    }
}
