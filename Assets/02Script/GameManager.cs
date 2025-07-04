using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerCharacterData
{
    public int characterID;
    public int level;
    public int exp;
    public bool isOwned;
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
    public List<int> formation01CharacterList;
}

public enum SceneName
{
    TitleScene,
    LobbyScene,
    CharacterScene,
    MissionScene,
    FormationScene,
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

        InitPlayerCharacters();
    }
    private void InitPlayerCharacters()
    {
        Debug.Log("Initalize player characters");

        data.playerCharacters = new List<PlayerCharacterData>();

        foreach (var characterData in DataManager.Instance.GetAllCharacterData())
        {
            CharacterData_Entity characterValue = characterData.Value;
            
            PlayerCharacterData playerCharacterData = new PlayerCharacterData();
            playerCharacterData.characterID = characterValue.ID;
            playerCharacterData.level = 1;
            playerCharacterData.exp = 0;
            playerCharacterData.isOwned = false;

            data.playerCharacters.Add(playerCharacterData);

            // collect character
        }

        data.formation01CharacterList = new List<int>() { -1, -1, -1, -1 };
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
        Debug.Log("Failed to get player data");

        return false;
    }
    // scene manager
    private SceneName nextSceneName;
    public SceneName NextScene => nextSceneName;
    public void AsyncLoadNextScene(SceneName nextScene)
    {
        nextSceneName = nextScene;
        SceneManager.LoadScene(nextScene.ToString());
    }
}
