using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sceneNameText;
    [SerializeField] private SceneNameSet sceneNameSet;
    private readonly Dictionary<SceneName, string> sceneNameDictionary
        = new Dictionary<SceneName, string>();

    [SerializeField] private TextMeshProUGUI playerEnergyText;
    [SerializeField] private TextMeshProUGUI playerCreditText;
    [SerializeField] private TextMeshProUGUI playerGemText;

    private int playerLevel;
    private PlayerLevelData_Entity playerLevelData;

    private GameObject obj;
    private Button button;

    private void Awake()
    {
        foreach (SceneNameData data in sceneNameSet.sceneNames)
        {
            sceneNameDictionary[data.sceneName] = data.sceneNameText;
        }
    }
    private void Start()
    {
        GameManager.Instance.GetPlayerData();
        DataManager.Instance.InitDataManager();

        RefreshPlayerResource();
    }
    private void RefreshPlayerResource()
    {
        StartCoroutine(RefreshPlayerResourceCoroutine());
    }
    private IEnumerator RefreshPlayerResourceCoroutine()
    {
        yield return null;
        GetPlayerLevelData();

        LoadSceneName();
        LoadPlayerEnergy();
        LoadPlayerCredit();
        LoadPlayerGem();
    }
    private void GetPlayerLevelData()
    {
        playerLevel = GameManager.Instance.Data.level;

        DataManager.Instance.GetPlayerLevelData(playerLevel, out playerLevelData);
    }
    private void LoadSceneName()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (Enum.TryParse(sceneName, out SceneName enumSceneName))
        {
            if (sceneNameDictionary.TryGetValue(enumSceneName, out string stringSceneName))
            {
                sceneNameText.text = stringSceneName;
            }
        }
    }
    private void LoadPlayerEnergy()
    {
        int currentEnergy = GameManager.Instance.Data.energy;
        int maxEnergy = playerLevelData.MaxEnergy;

        playerEnergyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
    }
    private void LoadPlayerCredit()
    {
        playerCreditText.text = GameManager.Instance.Data.gold.ToString();
    }
    private void LoadPlayerGem()
    {
        playerGemText.text = GameManager.Instance.Data.gem.ToString();
    }
}