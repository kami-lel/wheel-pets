using System.Collections.Generic;
using UnityEngine;

public class FeedLocalizationManager : MonoBehaviour
{
    public static FeedLocalizationManager Instance;

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
                    { "i_want_text", "I want... " },
                    { "foods_left_text", "Foods Left: {0}" }
                }
            },
            {
                "fr", new Dictionary<string, string>
                {
                    { "i_want_text", "Je veux... " },
                    { "foods_left_text", "Nourriture restante : {0}" }
                }
            },
            {
                "es", new Dictionary<string, string>
                {
                    { "i_want_text", "Quiero... " },
                    { "foods_left_text", "Comida restante: {0}" }
                }
            }
        };
    }

    public string GetTranslation(string key, params object[] args)
    {
        string language = Data.GetPlayerData().language;
        if (translations.ContainsKey(language))
        {
            if (translations[language].ContainsKey(key))
            {
                return string.Format(translations[language][key], args);
            }
        }
        return $"Translation not found for key: {key}";
    }
}