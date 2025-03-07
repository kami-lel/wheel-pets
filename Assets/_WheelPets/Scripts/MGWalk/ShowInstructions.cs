using UnityEngine;
using UnityEngine.UI;

public class ShowInstructions : MonoBehaviour
{
    public GameObject instructionsPanel; // Assign the existing Instructions UI GameObject in Inspector

    void Start()
    {
        if (instructionsPanel == null)
        {
            Debug.LogError("InstructionsPanel is not assigned in the Inspector!");
            return;
        }

        instructionsPanel.SetActive(false); // Ensure instructions start hidden
    }

    public void ToggleInstructions()
    {
        if (instructionsPanel == null) return;

        bool isCurrentlyActive = instructionsPanel.activeSelf;
        instructionsPanel.SetActive(!isCurrentlyActive);

        Debug.Log(isCurrentlyActive ? "Hiding instructions..." : "Showing instructions...");
    }
}
