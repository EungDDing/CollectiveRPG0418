using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Buttontype
{
    Character = 0,
    Formation, 
    Shop,
    Recruit,
    Mission,
    LobbyCharacter,
    Menu,
    EnergyCharge,
    GemCharge,
}
public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerIDText;
    [SerializeField] private TextMeshProUGUI playerLevelText;
    [SerializeField] private Image playerEXPImage;
    [SerializeField] private TextMeshProUGUI playerEXPText;
    [SerializeField] private TextMeshProUGUI playerEnergyText;
    [SerializeField] private TextMeshProUGUI playerCreditText;
    [SerializeField] private TextMeshProUGUI playerGemText;

    private int playerLevel;
    private PlayerLevelData_Entity playerLevelData;

    private GameObject obj;
    private Button button;

    private void Awake()
    {
        InitButton();
    }
    private void Start()
    {
        RefreshPlayerInfo();
    }
    // refresh UI
    public void RefreshPlayerInfo()
    {
        StartCoroutine(RefreshPlayerInfoCoroutine());
    }
    private IEnumerator RefreshPlayerInfoCoroutine()
    {
        yield return null;
        LoadPlayerID();
        LoadPlayerLevel();
        GetPlayerLevelData();
        LoadPlayerEXP();
        LoadPlayerEnergy();
        LoadPlayerCredit();
        LoadPlayerGem();
    }
    private void LoadPlayerID()
    {
        playerIDText.text = GameManager.Instance.Data.playerID;
    }
    private void LoadPlayerLevel()
    {
        playerLevel = GameManager.Instance.Data.level;
        playerLevelText.text = playerLevel.ToString();
    }
    private void GetPlayerLevelData()
    {
        DataManager.Instance.GetPlayerLevelData(playerLevel, out playerLevelData);
    }
    private void LoadPlayerEXP()
    {
        int currentEXP = GameManager.Instance.Data.currentEXP;
        int maxEXP = playerLevelData.PlayerExp;

        playerEXPText.text = currentEXP.ToString() + "/" + maxEXP.ToString();
        playerEXPImage.fillAmount = (float)currentEXP / maxEXP;
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

    // button
    private void InitButton()
    {
        obj = GameObject.Find("CharacterListButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.Character));
            }
        }
        obj = GameObject.Find("FormationButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.Formation));
            }
        }
        obj = GameObject.Find("ShopButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.Shop));
            }
        }
        obj = GameObject.Find("RecruitButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.Recruit));
            }
        }
        obj = GameObject.Find("MissionButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.Mission));
            }
        }
        obj = GameObject.Find("LobbyCharacterSelectButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.LobbyCharacter));
            }
        }
        obj = GameObject.Find("MenuButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.Menu));
            }
        }
        obj = GameObject.Find("EnergyChargeButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.EnergyCharge));
            }
        }
        obj = GameObject.Find("GemChargeButton");
        if (obj != null)
        {
            if (obj.TryGetComponent<Button>(out button))
            {
                button.onClick.AddListener(() => HandleButtonOnClick(Buttontype.GemCharge));
            }
        }
    }
    private void HandleButtonOnClick(Buttontype buttontype)
    {
        switch (buttontype)
        {
            case Buttontype.Character:
                GoCharacterScene();
                break;
            case Buttontype.Formation:
                Debug.Log("Formation Button");
                break;
            case Buttontype.Shop:
                Debug.Log("Shop Button");
                break;
            case Buttontype.Recruit:
                Debug.Log("Recruit Button");
                break;
            case Buttontype.Mission:
                Debug.Log("Mission Button");
                break;
            case Buttontype.LobbyCharacter:
                Debug.Log("LobbyCharacter Button");
                break;
            case Buttontype.Menu:
                Debug.Log("Menu Button");
                break;
            case Buttontype.EnergyCharge:
                Debug.Log("EnergyCharge Button");
                break;
            case Buttontype.GemCharge:
                Debug.Log("GemCharge Button");
                break;
        }
    }
    public void GoCharacterScene()
    {
        GameManager.Instance.AsyncLoadNextScene(SceneName.CharacterScene);
    }
}
