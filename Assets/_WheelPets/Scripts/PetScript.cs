using UnityEngine;
using UnityEngine.Rendering;

public class PetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject dog;

    [SerializeField]
    private GameObject cat;

    [SerializeField]
    private GameObject rabbit;

    private PlayerData playerData;
    private PlayerData.PetData petData;

    private void Start()
    {
        playerData = PlayerData.LoadFromFile();
        petData = playerData.petData;
        StartPet();
        StartSyncAnimations();
    }

    private void StartPet()
    {
        switch (petData.animalType)
        {
            case 0:
                dog.SetActive(true);
                break;

            case 1:
                cat.SetActive(true);
                break;

            case 2:
                rabbit.SetActive(true);
                break;

            default:
                dog.SetActive(true);
                break;
        }
    }

    private void StartSyncAnimations()
    {
        // TODO
    }

    private void Update() { }

    private void OnApplicationQuit()
    {
        PlayerData.SaveToFile();
    }
}
