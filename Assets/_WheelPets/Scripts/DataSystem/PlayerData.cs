using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[Serializable]
public class PlayerData
{
    // initialize with <b>default value</b>, i.e. factory reset value
    public string playerName = "Pet Owner";
    public int drivingPoint = 0;
    public int minigameCoin = 0;

    public LeaderboardOtherPlayerData[] leaderBoardOtherPlayerData = new[]
    {
        new LeaderboardOtherPlayerData { name = "John", point = 123 },
        new LeaderboardOtherPlayerData { name = "Emma", point = 234 },
        new LeaderboardOtherPlayerData { name = "Oliver", point = 198 },
        new LeaderboardOtherPlayerData { name = "Sophia", point = 265 },
        new LeaderboardOtherPlayerData { name = "Liam", point = 121 },
        new LeaderboardOtherPlayerData { name = "Ava", point = 289 },
        new LeaderboardOtherPlayerData { name = "Ethan", point = 177 },
        new LeaderboardOtherPlayerData { name = "Isabella", point = 256 },
        new LeaderboardOtherPlayerData { name = "Mason", point = 210 },
        new LeaderboardOtherPlayerData { name = "Mia", point = 178 },
    };

    // fixme better data structure
    // driving statistics
    public int leftTurnSignals = 0;
    public int rightTurnSignals = 0;
    public int timesParkedWithoutTouchingLines = 0;
    public int stopSignsStoppedAt = 0;

    // BUG these data fields are deprecated
    public int tugOfWarGamesWon = 0;
    public int timesPetWashed = 0;
    public int timesHideNSeekWon = 0;
    public int cosmeticsUnlocked = 0;
    public int timesPetWalked = 0;
    public int fetchHighScore = 0;
    public float bathMinigameBestTime = 60f;

    // Audio settings
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    public bool muteMusic = false;
    public bool muteSfx = false;

    // fixme combine fileds before and after this line
    public float mainVolume = 0.75f; // 0~1
    public float bgmVolume = 1f;

    // statistics of minigames
    public MinigameStatistics statBath = new("bath");
    public MinigameStatistics statFeed = new("feed");
    public MinigameStatistics statFetch = new("fetch");
    public MinigameStatistics statHide = new("hide");
    public MinigameStatistics statTug = new("tug");
    public MinigameStatistics statWalk = new("walk");

    /// <summary>
    /// Retrieve all minigame statistics as a dictionary.
    /// This function provides access to all stat objects for the purpose
    /// of iteration and data manipulation.
    /// </summary>
    /// <returns>A dictionary containing the minigame statistics.</returns>
    public Dictionary<string, MinigameStatistics> GetAllStats()
    {
        // Create a dictionary to hold the statistics of minigames
        var statsDictionary = new Dictionary<string, MinigameStatistics>
        {
            { "bath", statBath },
            { "feed", statFeed },
            { "fetch", statFetch },
            { "hide", statHide },
            { "tug", statTug },
            { "walk", statWalk },
        };

        return statsDictionary; // Return the populated dictionary
    }

    // pet's data
    public bool hasAdoptPet = false;
    public PetData petData = new();
    public List<AccessoryType> purchasedAccessories = new();

    public void ChangeAnimalType(AnimalType animalType)
    {
        // reset pet data
        petData = new();

        petData.animalType = animalType;
        // todo get a random name for pet
    }

    // Language preference
    public string language = "en";

    // declare classes
    [Serializable]
    public class LeaderboardOtherPlayerData
    {
        public string name;
        public int point;
    }

    [Serializable]
    public enum AnimalType
    {
        Dog,
        Cat,
        Rabbit,
    }

    [Serializable]
    public class PetData
    {
        public string name = "Buddy";
        public AnimalType animalType = AnimalType.Dog;
        public float dominantColorHue = 0f;
        public float secondaryColorHue = 0f;
        public List<AccessoryType> currentAccessories = new();
    }
}
