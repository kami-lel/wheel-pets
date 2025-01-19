/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
* Inspector: Apply this script component to the player game object.
* Jumper: A script that ensures the player game object exists before applying 
*         upward velcoity for the jump.
* Issue: Jumper only works some of the time?
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using UnityEngine;

public class CompletedJumper : MonoBehaviour{
    public Rigidbody2D body; // Rigidbody2D component for the player (assign in Inspector)
    public float jumpAmount = 5f; // Adjust jump strength as needed

    public void Jump(){
        // Check if Rigidbody2D is assigned throughout the game. If not don't jump.
        if (body == null){
            Debug.LogError("Rigidbody2D (body) is null! Assign it in the Inspector.");
            return;
        }

        // Apply upward velocity to make the player jump
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpAmount);
        Debug.Log("Player jumped!");
    }


    private void Start(){
        // Check if Rigidbody2D is assigned at the start of the game
        if (body == null) Debug.LogError("Assign the Player Rigidbody to Body in the Inspector.");
    }
}
