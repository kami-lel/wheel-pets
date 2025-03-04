using UnityEngine;

public class DataSystemPrefabScript : MonoBehaviour
{
    void Update()
    {
        // todo timed auto-save
    }

    void OnApplicationQuit()
    {
        Data.SavePlayerDataToFile();
    }
}
