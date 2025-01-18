using UnityEngine;

public class StartDrivingGame : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonsToHide; // Array to store buttons to hide
    [SerializeField] private string drivingGamePrefabName; // Name of the prefab in the Resources folder
    [SerializeField] private GameObject jumpButton; // Reference to the jump button
    [SerializeField] private LayerMask groundLayer; // Layer mask to specify what is considered "ground"

    private GameObject instantiatedPrefab; // Reference to the instantiated prefab
    private bool isTouchingGround; // Flag to check if the object is on the ground

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

    void Update()
    {
        // Enable or disable the jump button based on whether the object is touching the ground
        if (jumpButton != null)
        {
            jumpButton.SetActive(isTouchingGround);
        }
    }

    // Check for collisions with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isTouchingGround = false;
        }
    }
}
