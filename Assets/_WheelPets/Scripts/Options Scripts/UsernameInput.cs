using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UsernameInput : MonoBehaviour, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
    public TMP_InputField usernameInputField;
    private string savedUsername = "";

    void Start()
    {
        if (usernameInputField != null)
        {
            usernameInputField.text = savedUsername;
            usernameInputField.interactable = true; // Ensure it's interactable
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ActivateInput();
    }

    public void OnSelect(BaseEventData eventData)
    {
        ActivateInput();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SaveUsername();
    }

    void ActivateInput()
    {
        if (usernameInputField != null)
        {
            usernameInputField.interactable = true;
            usernameInputField.readOnly = false; // Ensure it's not read-only
            usernameInputField.ActivateInputField();
        }
    }

    void SaveUsername()
    {
        if (usernameInputField != null)
        {
            savedUsername = usernameInputField.text;
            usernameInputField.readOnly = true; // Prevent accidental editing
        }
    }
}
