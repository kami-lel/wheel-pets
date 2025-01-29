using UnityEngine;
using UnityEngine.UI;

public class DrivingControls : MonoBehaviour
{
    // Serialized fields for UI buttons
    [SerializeField] private Button gasPedalButton;
    [SerializeField] private Button brakeButton;
    [SerializeField] private Button leftBlinkerButton;
    [SerializeField] private Button rightBlinkerButton;
    [SerializeField] private Button reverseButton;
    [SerializeField] private Button driveButton;
    [SerializeField] private Button parkButton;
    [SerializeField] private Button checkLeftButton;
    [SerializeField] private Button checkRightButton;
    [SerializeField] private Button checkRearButton;

    private void Start()
    {
        // Assign button listeners
        if (gasPedalButton != null)
            gasPedalButton.onClick.AddListener(OnGasPedalPressed);

        if (brakeButton != null)
            brakeButton.onClick.AddListener(OnBrakePressed);

        if (leftBlinkerButton != null)
            leftBlinkerButton.onClick.AddListener(OnLeftBlinkerPressed);

        if (rightBlinkerButton != null)
            rightBlinkerButton.onClick.AddListener(OnRightBlinkerPressed);

        if (reverseButton != null)
            reverseButton.onClick.AddListener(OnReversePressed);

        if (driveButton != null)
            driveButton.onClick.AddListener(OnDrivePressed);

        if (parkButton != null)
            parkButton.onClick.AddListener(OnParkPressed);
        
        if (checkLeftButton != null)
            checkLeftButton.onClick.AddListener(CheckLeftPress);
        
        if (checkRightButton != null)    
            checkRightButton.onClick.AddListener(CheckRightPress);
        
        if (checkRearButton != null)
            checkRearButton.onClick.AddListener(CheckRearPress);
    }

    // Button action methods
    private void OnGasPedalPressed()
    {
        Debug.Log("Gas pedal pressed. Accelerating...");
        // Add gas pedal logic here
    }

    private void OnBrakePressed()
    {
        Debug.Log("Brake pressed. Slowing down...");
        // Add brake logic here
    }

    private void OnLeftBlinkerPressed()
    {
        Debug.Log("Left blinker activated.");
        // Add left blinker logic here
    }

    private void OnRightBlinkerPressed()
    {
        Debug.Log("Right blinker activated.");
        // Add right blinker logic here
    }

    private void OnReversePressed()
    {
        Debug.Log("Reverse gear engaged.");
        // Add reverse logic here
    }

    private void OnDrivePressed()
    {
        Debug.Log("Drive gear engaged.");
        // Add drive logic here
    }

    private void OnParkPressed()
    {
        Debug.Log("Car parked.");
        // Add park logic here
    }
    private void CheckLeftPress(){
        Debug.Log("You checked the left window for cars.");
    }
    private void CheckRightPress(){
        Debug.Log("You checked the right window for cars.");
    }
    private void CheckRearPress(){
        Debug.Log("You checked the rear window for cars.");
    }
}
