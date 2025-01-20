/* * * * * * * * * * * * 
* Inspector: Apply this script component to the player game object.
* InputController: A script that ensures the player game object exists before getting 
*                  jump input and jumping.
* * * * * * * * * * * * */
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour{
    // Add these values to the Inspector 
    public CompletedJumper jumper; 
    public AudioSource jumpSound; 
    private bool jumpRequested = false; // Buffer for jump input

    private void Start(){
        // Check if jumper and jumpSound is assigned, otherwise attempt to find it
        if (jumper == null) Debug.Log("Assign Jumper in InputController.");
        if (jumpSound == null) Debug.Log("Attach the jumpSound in the Inspector.");
    }

    private void Update()
    {
        // If jumper is not assigned, do nothing
        if (jumper == null) return;

        // Detect jump input and buffer it
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequested = true; // Buffer the input
            Debug.Log("Jump input buffered.");
        }
    }

    private void FixedUpdate()
    {
        // Process the buffered jump input
        if (jumpRequested)
        {
            jumper.Jump();
            Debug.Log("Jump executed in FixedUpdate.");

            // Play sound if AudioSource is assigned
            if (jumpSound != null) jumpSound.Play();

            jumpRequested = false; // Clear the buffer
        }
    }
}
