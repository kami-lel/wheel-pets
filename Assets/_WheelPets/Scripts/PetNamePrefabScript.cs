using TMPro;

public class PetNamePrefabScript : TextMeshProUGUI
{
    protected override void Start()
    {
        base.Start(); // Calling the parent class's Start method
        text = Data.GetPlayerData().petData.name;
    }
}
