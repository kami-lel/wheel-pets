using UnityEngine;

public class DataSystemPrefabScript : MonoBehaviour
{
    void Update()
    {
        // TODO timed auto-save
    }

    void OnApplicationQuit()
    {
        Data.SavePlayerDataToFile();
    }
}
