using UnityEngine;

public class PauseOverlay : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // pause screen is disabled by default
        container.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }
}
