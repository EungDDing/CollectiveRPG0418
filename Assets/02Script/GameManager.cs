using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerCharacterData
{
    public int characterID;
    public int level;
    public int exp;
    public bool isOwned;
    public bool isAllocated;
}
[System.Serializable]
public class PlayerData
{
    public string playerID;
    public int level;
    public int currentEXP;
    public int gold;
    public int gem;
    public int energy;

    public List<PlayerCharacterData> playerCharacters;
}
public class GameManager : Singleton<GameManager>
{
    private PlayerData data;
    public PlayerData Data
    {
        get => data;
    }
    PlayerLevelData_Entity playerLevelData;

    protected override void DoAwake()
    {
        base.DoAwake();
        dataPath = Application.persistentDataPath + "/Save";
    }
    public void CreatePlayerData(string playerID)
    {
        data = new PlayerData();

        data.playerID = playerID;
        data.level = 1;
        data.currentEXP = 0;
        data.gold = 0;
        data.gem = 1000;
        data.energy = 0;
        data.playerCharacters = new List<PlayerCharacterData>();
    }

    // save & load player data
    private string dataPath;
    // save data
    public void SaveData()
    {
        string playerDataString = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, playerDataString);
    }
    // load data
    public bool LoadData()
    {
        if (File.Exists(dataPath))
        {
            string playerDataString = File.ReadAllText(dataPath);
            data = JsonUtility.FromJson<PlayerData>(playerDataString);
            return true;
        }
        return false;
    }
    // delete data
    public void DeleteData()
    {
        File.Delete(dataPath);
    }
    // check save file and load data
    public bool GetPlayerData()
    {
        if (File.Exists(dataPath))
        {
            return LoadData();
        }
        return false;
    }
}
