using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
    private void Start()
    {
        PlayerData.LoadFromFile();
        PlayerData.SaveToFile();
    }
}
