using UnityEngine;

// FIXME blade various playtest improve:
// Change the collider to work with the letters.
//  Increase driving speed
//  Add in the driving scenario text
//  Convey clearly that  you have points to spend in the pet game as a result of what you did in the driving game
//  Make the turn signal UI intuitive through art dept
//  Add Instructions for controls
// FIXME blade connect data w/ pet game
// BUG blade runtime error The referenced script (Unknown) on this Behaviour is missing!
public class DrivingSimSceneScript : MonoBehaviour
{
    public void ExitSimluationButtonOnClick()
    {
        Application.Quit();
    }
}
