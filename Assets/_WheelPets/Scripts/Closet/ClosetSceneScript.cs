using TMPro;
using UnityEngine;

public class ClosetSceneScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinValueText;

    private PlayerData playerData;

    public void BackButtonOnClick()
    {
        SceneChange.LoadTitle();
    }

    private void Start()
    {
        playerData = Data.GetPlayerData();
    }

    private void Update()
    {
        coinValueText.text = playerData.minigameCoin.ToString();
    }
}
