using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSceneUIManager : MonoBehaviour
{
    [SerializeField] private Image characterListImage;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private RectTransform contentTransform;


    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI armorText;
    [SerializeField] private TextMeshProUGUI healingText;

    [SerializeField] private List<Image> roles;
    [SerializeField] private TextMeshProUGUI positionText;
    [SerializeField] private Image attackTypeImage;
    [SerializeField] private TextMeshProUGUI attackTypeText;
    [SerializeField] private Image defenceTypeImage;
    [SerializeField] private TextMeshProUGUI defenceTypeText;
    [SerializeField] private List<Image> weapons;

    [SerializeField] private Image skillImageBackground;
    [SerializeField] private TextMeshProUGUI skillNameText;
    [SerializeField] private TextMeshProUGUI skillInfoText;
    [SerializeField] private TextMeshProUGUI skillCostText;

    private List<CharacterCard> cards = new List<CharacterCard>();
    private CharacterCard card;

    private CharacterBase characterBase;

    private CharacterData_Entity characterData;
    private SkillData_Entity skillData;

    private int cardCount;

    private readonly Dictionary<string, Image> roleDictionary = new Dictionary<string, Image>();

    [SerializeField] private PositionUISet positionUISet;
    private readonly Dictionary<string, string> positionDictionary = new Dictionary<string, string>();
    
    [SerializeField] private AttackTypeUISet attackTypeUISet;
    private readonly Dictionary<string, (Color color, string text)> attackTypeDictionary
        = new Dictionary<string, (Color color, string text)>();

    [SerializeField] private DefenceTypeUISet defenceTypeUISet;
    private readonly Dictionary<string, (Color color, string text)> defenceTypeDictionary
        = new Dictionary<string, (Color color, string text)>();
    
    private readonly Dictionary<string, Image> weaponDictionary = new Dictionary<string, Image>();

    private void Awake()
    {
        InitCards();

        foreach (PositionUIData data in positionUISet.positions)
        {
            positionDictionary[data.positionKey] = data.label;
        }
        foreach (AttackTypeUIData data in attackTypeUISet.attackTypes)
        {
            attackTypeDictionary[data.typeKey] = (data.color, data.label);
        }
        foreach (DefenceTypeUIData data in defenceTypeUISet.defenceTypes)
        {
            defenceTypeDictionary[data.typeKey] = (data.color, data.label);
        }

        roleDictionary["Attack"] = roles[0];
        roleDictionary["Support"] = roles[1];
        roleDictionary["Defence"] = roles[2];

        weaponDictionary["AR"] = weapons[0];
        weaponDictionary["HG"] = weapons[1];
        weaponDictionary["SG"] = weapons[2];
        weaponDictionary["SMG"] = weapons[3];
        weaponDictionary["SR"] = weapons[4];
    }
    private void Start()
    {
        
    }
    // character List
    private void InitCards()
    {
        cardCount = 10;
        for (int i = 0; i < cardCount; i++)
        {
            if (Instantiate(cardPrefab, contentTransform).TryGetComponent<CharacterCard>(out card))
            {
                cards.Add(card);
            }
        }
    }
    public void RefreshCharacterListUI()
    {
        for (int i = 0; i < cardCount; i++)
        {
            cards[i].DrawCharacterCard(i);

            cards[i].OnClickCharacterCard -= ClickCharacterCard;
            cards[i].OnClickCharacterCard += ClickCharacterCard;

            cards[i].OnClickCharacterCard -= CharacterSceneManager.Instance.ShowCharacter;
            cards[i].OnClickCharacterCard += CharacterSceneManager.Instance.ShowCharacter;

            cards[i].OnClickCharacterCard -= ShowCharacterInfo;
            cards[i].OnClickCharacterCard += ShowCharacterInfo;
        }
    }
    private void ClickCharacterCard(int id)
    {
        characterListImage.gameObject.LeanScale(Vector3.zero, 0.3f).setEase(LeanTweenType.easeInOutElastic);
    }
    
    // character info
    private void ShowCharacterInfo(int id)
    {
        characterBase = FindAnyObjectByType<CharacterBase>();
        Debug.Log(id);
        DataManager.Instance.GetCharacterData(id, out characterData);
        DataManager.Instance.GetSkillData(id, out skillData);
  
        StartCoroutine(ShowInfo(id));
    }
    private IEnumerator ShowInfo(int id)
    {
        yield return null;

        hpText.text = characterBase.MaxHP.ToString();
        attackText.text = characterBase.Attack.ToString();
        armorText.text = characterBase.Armor.ToString();
        healingText.text = characterBase.Healing.ToString();

        foreach (Image image in roles)
        {
            image.gameObject.SetActive(false);
        }
        if (roleDictionary.TryGetValue(characterData.Role, out Image role))
        {
            role.gameObject.SetActive(true);
        }

        if (positionDictionary.TryGetValue(characterData.Position, out string position))
        {
            positionText.text = position;
        }
        
        if (attackTypeDictionary.TryGetValue(characterData.AttackType, out (Color color, string text) attackType))
        {
            attackTypeImage.color = attackType.color;
            attackTypeText.text = attackType.text;

            skillImageBackground.color = attackType.color;
        }

        if (defenceTypeDictionary.TryGetValue(characterData.DefenceType, out (Color color, string text) defenceType))
        {
            defenceTypeImage.color = defenceType.color;
            defenceTypeText.text = defenceType.text;
        }

        foreach (Image image in weapons)
        {
            image.gameObject.SetActive(false);
        }
        if (weaponDictionary.TryGetValue(characterData.Weapon, out Image weapon))
        {
            weapon.gameObject.SetActive(true);
        }

        skillNameText.text = skillData.Skill;
        skillInfoText.text = skillData.SkillInfo;
        skillCostText.text = "COST : " + skillData.SkillCost.ToString();
    }
}
