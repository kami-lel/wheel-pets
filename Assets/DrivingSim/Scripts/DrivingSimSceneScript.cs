using UnityEngine;

// FIXME Change the collider to work with the letters.
// FIXME Increase driving speed
// FIXME Add in the driving scenario text
// FIXME Convey clearly that  you have points to spend in the pet game as a result of what you did in the driving game
// FIXME Make the turn signal UI intuitive through art dept
// FIXME Add Instructions for controls
// FIXME connect data w/ pet game
// BUG runtime error The referenced script (Unknown) on this Behaviour is missing!
// BUG no way of exiting the simulation
public class DrivingSimSceneScript : MonoBehaviour
{
    public void ExitSimluationButtonOnClick()
    {
        Application.Quit();
    }
}
