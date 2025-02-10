using System;
using UnityEngine;

public class PlayerData
{
    // initialize with <b>default value</b>, i.e. factory reset value
    public string playerName = "Pet Owner";
    public int drivingPoint = 0;
    public int gamePoint = 0;
    public float drivingMiles = 0;

    public LeaderboardOtherPlayerData[] leaderBoardOtherPlayerData =
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

    // fixme better data structure
    //  minigame statistics
    public int tugOfWarGamesWon = 0;
    public int timesPetWashed = 0;
    public int timesHideNSeekWon = 0;
    public int cosmeticsUnlocked = 0;

    // statistics of mini games
    public MinigameStatistics statBath = new();
    public MinigameStatistics statFeed = new();
    public MinigameStatistics statFetch = new();
    public MinigameStatistics statHideNSeek = new();
    public MinigameStatistics statTugOWar = new();
    public MinigameStatistics statWalkScene = new();

    // pet's data
    public bool hasAdoptPet = false;
    public PetData petData = new();

    public float mainVolume = 0.75f; // 0~1
    public float sfxVolume = 1f;
    public float bgmVolume = 1f;

    // declare classes
    [Serializable]
    public class LeaderboardOtherPlayerData
    {
        public string name;
        public int point;
    }

    [Serializable]
    public class MinigameStatistics
    {
        public int playCount = 0;
        public int winCount = 0;
    }

    [Serializable]
    public class PetData
    {
        public string name = "Buddy";
        public int animalType = 0;
        public float dominantColorHue = 0f;
        public float secondaryColorHue = 0f;
    }
}
