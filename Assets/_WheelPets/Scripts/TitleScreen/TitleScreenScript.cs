using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
    private void Start()
    {
        PlayerData.LoadFromFile();
        PlayerData playerData = PlayerData.Data;
        Debug.Log(playerData); // HACK
    }

    private void OnApplicationQuit()
    {
        PlayerData.SaveToFile();
    }
}
