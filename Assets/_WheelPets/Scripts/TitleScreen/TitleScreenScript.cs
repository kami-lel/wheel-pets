using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
    private void Start()
    {
        PlayerData.LoadFromFile();
    }

    private void OnApplicationQuit()
    {
        PlayerData.SaveToFile();
    }
}
