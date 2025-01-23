using UnityEngine;

public class TugOfWarTapping : MonoBehaviour
{
    public TugOfWarManager tugOfWarManager;
    public float tapMoveSpeed = 2.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detects mouse click or screen tap
        {
            if (tugOfWarManager != null && tugOfWarManager.IsGameStarted())
            {
                MoveRopeLineLeft();
            }
        }
    }

    void MoveRopeLineLeft()
    {
        if (tugOfWarManager != null && tugOfWarManager.ropeLine != null)
        {
            tugOfWarManager.ropeLine.transform.Translate(Vector3.left * tapMoveSpeed);
        }
        else
        {
            Debug.LogWarning("TugOfWarManager or ropeLine is not assigned");
        }
    }
}
