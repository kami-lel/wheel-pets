using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    private Dictionary<string, Dictionary<string, string>> translations;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeTranslations();
    }

    private void InitializeTranslations()
    {
        translations = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "en", new Dictionary<string, string>
            {
                { "brush_message", "The dog is brushed and looking tidy." },
                { "clippers_message", "The dog has been clipped." },
                { "soap_message", "The dog is lathered." },
                { "water_message", "The dog is rinsed." },
                { "towel_message", "The dog is dried off." },
                { "scissors_message", "All done" },
                { "mistake_message", "You can't use that yet." },
                { "timer_text", "Lowest Time: {0}s\nTime: {1}s" } // Added timer text
            }
        },
        {
            "fr", new Dictionary<string, string>
            {
                { "brush_message", "Le chien est brossé et a l'air soigné." },
                { "clippers_message", "Le chien a été tondu." },
                { "soap_message", "Le chien est savonné." },
                { "water_message", "Le chien est rincé." },
                { "towel_message", "Le chien est séché." },
                { "scissors_message", "Terminé" },
                { "mistake_message", "Vous ne pouvez pas encore utiliser cela." },
                { "timer_text", "Meilleur temps : {0}s\nTemps : {1}s" } // Added timer text
            }
        },
        {
            "es", new Dictionary<string, string>
            {
                { "brush_message", "El perro está cepillado y se ve ordenado." },
                { "clippers_message", "El perro ha sido recortado." },
                { "soap_message", "El perro está enjabonado." },
                { "water_message", "El perro está enjuagado." },
                { "towel_message", "El perro está seco." },
                { "scissors_message", "Todo listo" },
                { "mistake_message", "No puedes usar eso todavía." },
                { "timer_text", "Mejor tiempo: {0}s\nTiempo: {1}s" } // Added timer text
            }
        }
    };
    }


    public string GetTranslation(string key)
    {
        string language = Data.GetPlayerData().language;
        if (translations.ContainsKey(language) && translations[language].ContainsKey(key))
        {
            return translations[language][key];
        }
        return $"Translation not found for key: {key}";
    }
}