using UnityEngine;

public class StartDrivingGame : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonsToHide; // Array to store buttons to hide
    [SerializeField] private string drivingGamePrefabName; // Name of the prefab in the Resources folder

    private GameObject instantiatedPrefab; // Reference to the instantiated prefab

    // Method to start the driving game, called when the button is clicked
    public void PlaytDrivingGame()
    {
        // Hide all the buttons in the array
        foreach (GameObject button in buttonsToHide)
        {
            if (button != null)
            {
                button.SetActive(false);
            }
        }

        // Load and instantiate the prefab from the Resources folder
        if (!string.IsNullOrEmpty(drivingGamePrefabName))
        {
            GameObject prefab = Resources.Load<GameObject>(drivingGamePrefabName);
            if (prefab != null)
            {
                instantiatedPrefab = Instantiate(prefab);
                instantiatedPrefab.SetActive(true); // Ensure it's active after instantiation
            }
            else
            {
                Debug.LogError($"Prefab with name '{drivingGamePrefabName}' not found in Resources folder.");
            }
        }
        else
        {
            Debug.LogError("DrivingGamePrefabName is not set in the Inspector.");
        }
    }
}
