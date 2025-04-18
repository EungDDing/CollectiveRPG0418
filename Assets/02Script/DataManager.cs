using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private CollectiveGame dataTable;
    private bool loadData = false;

    private Dictionary<int, CharacterData_Entity> characterDataDictionary = new Dictionary<int, CharacterData_Entity>();
    private Dictionary<int, LevelData_Entity> levelDataDictionary = new Dictionary<int, LevelData_Entity>();
    private Dictionary<int, PlayerLevelData_Entity> playerLevelDataDictionary = new Dictionary<int, PlayerLevelData_Entity>();
    public bool GetCharacterData(int key, out CharacterData_Entity characterData)
    {
        return characterDataDictionary.TryGetValue(key, out characterData);
    }

    public bool GetLevelData(int level, out LevelData_Entity levelData)
    {
        return levelDataDictionary.TryGetValue(level, out levelData);
    }
    public bool GetPlayerLevelData(int playerLevel, out PlayerLevelData_Entity playerLevelData)
    {
        return playerLevelDataDictionary.TryGetValue(playerLevel, out playerLevelData);
    }
    public void InitDataManager()
    {
        if (!loadData)
        {
            loadData = true;

            for (int i = 0; i < dataTable.CharacterData.Count; i++)
            {
                characterDataDictionary.Add(dataTable.CharacterData[i].ID, dataTable.CharacterData[i]);
            }
            for (int i = 0; i < dataTable.LevelData.Count; i++)
            {
                levelDataDictionary.Add(dataTable.LevelData[i].Level, dataTable.LevelData[i]);
            }
            for (int i = 0; i < dataTable.PlayerLevelData.Count; i++)
            {
                playerLevelDataDictionary.Add(dataTable.PlayerLevelData[i].PlayerLevel, dataTable.PlayerLevelData[i]);
            }
        }
    }
    protected override void DoAwake()
    {
        InitDataManager();
    }
}
