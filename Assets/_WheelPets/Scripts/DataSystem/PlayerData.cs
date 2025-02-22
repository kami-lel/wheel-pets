using System;
using System.Collections.Generic;

public class PlayerData
{
    // initialize with <b>default value</b>, i.e. factory reset value
    public string playerName = "Pet Owner";
    public int drivingPoint = 0;
    public int gamePoint = 0;
    public float drivingMiles = 0;

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

    // FIXME better data structure
    //  minigame statistics
    public int tugOfWarGamesWon = 0;
    public int timesPetWashed = 0;
    public int timesHideNSeekWon = 0;
    public int cosmeticsUnlocked = 0;

    // High score for the fetch minigame
    public int fetchHighScore = 0;

    // Best time for the bath minigame
    public float bathMinigameBestTime = 60f;

    // Audio settings
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    public bool muteMusic = false;
    public bool muteSfx = false;

    // FIXME combine fileds before and after this line
    public float mainVolume = 0.75f; // 0~1
    public float bgmVolume = 1f;

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
    public List<PetAccessory> purchasedAccessories = new();

    // declare classes
    [Serializable]
    public class LeaderboardOtherPlayerData
    {
        public string name;
        public int point;
    }

    // TODO add high score
    // FIXME makesure these are connected with the game
    [Serializable]
    public class MinigameStatistics
    {
        public int playCount = 0;
        public int winCount = 0;
    }

    /// <summary>
    /// Data type for pet accessories.
    /// Renderable in PetPrefab, purchasable in Store, and usable in Closet.
    /// </summary>
    [Serializable]
    public enum PetAccessory
    {
        Atelier,
        CloudyGlasses,
        DeliveryCap,
        HawaiianFlower,
        Leaf,
        PiratePatch,
        PrettyBow,
        RainbowHeadband,
        StarCowlo,
        UnicornHorn,
        XDDCC,
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
        public List<PetAccessory> currentAccessories = new();
    }
}
