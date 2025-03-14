using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class BathLang : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerText();
        
    }

    public void DisplayMessage(string key)
    {
        if (messageText != null)
        {
            messageText.text = GetLocalizedText(key);
        }
    }

    private void UpdateTimerText()
    {
        float bestTime = Data.GetPlayerData().statBath.bestScore;
        if (timerText != null)
        {
            timerText.text = $"Lowest Time: {bestTime:F2}s\nTime: {timer:F2}s";
        }
    }

    private string GetLocalizedText(string key)
{
    string language = Data.GetPlayerData().language;
    Debug.Log($"Current Language: {language}"); // Debugging language value
    
    var translations = new Dictionary<string, Dictionary<string, string>> {
        { "en", new Dictionary<string, string> {
            { "pet_brushed", "The pet is brushed and looking tidy." },
            { "pet_clipped", "The pet has been clipped." },
            { "pet_lathered", "The pet is lathered." },
            { "pet_rinsed", "The pet is rinsed." },
            { "pet_dried", "The pet is dried off." },
            { "all_done", "All done." },
            { "you_cant_use_that_yet", "You can't use that yet." }
        }},
        { "fr", new Dictionary<string, string> {
            { "pet_brushed", "L'animal est brossé et bien propre." },
            { "pet_clipped", "L'animal a été tondu." },
            { "pet_lathered", "L'animal est savonné." },
            { "pet_rinsed", "L'animal est rincé." },
            { "pet_dried", "L'animal est séché." },
            { "all_done", "Tout est terminé." },
            { "you_cant_use_that_yet", "Vous ne pouvez pas encore l'utiliser." }
        }},
        { "es", new Dictionary<string, string> {
            { "pet_brushed", "La mascota está cepillada y bien arreglada." },
            { "pet_clipped", "La mascota ha sido recortada." },
            { "pet_lathered", "La mascota está enjabonada." },
            { "pet_rinsed", "La mascota está enjuagada." },
            { "pet_dried", "La mascota está seca." },
            { "all_done", "Todo listo." },
            { "you_cant_use_that_yet", "No puedes usar eso todavía." }
        }}
    };

    if (translations.ContainsKey(language) && translations[language].ContainsKey(key))
    {
        return translations[language][key];
    }

    return key;
}

}