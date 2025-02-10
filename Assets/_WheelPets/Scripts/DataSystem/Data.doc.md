# data system docs

## PlayerData

**PlayerData** store persistent data across different scenes and between play sessions. Such as player name, game stat, pet apperearance, audio settings, etc.

PlayerData can be reset in option scene.



### use PlayerData in code

Setup:

```
public class MyScene : MonoBehavior {

    private PlayerData playerData;

    private void Start() {
        playerData = Data.GetPlayerData();
        ...
    }

    private void OnApplicationQuit()
    {
        Data.SavePlayerDataToFile();
    }

}
```

(Make sure data loads from file, and will be saved to file when application ends)

----

Then read / write to the data:

```
Debug.Log(playerData.playerName);
playerData.playerName = "John";
```



### add new fields

Edit `PlayerData.cs` to add more data fields you wish to store.

Remember to provide a *default* value which will be used during reset.

Add `[Serializable]` before classes declared in `PlayerData`, such that they can be converted to/from JSON file.













## ParameterData

**ParameterData** store constant values such as award for each good driving behavior, unlocking point for mini games, ...

TODO