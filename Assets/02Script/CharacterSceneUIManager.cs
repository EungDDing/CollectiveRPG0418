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

    private List<CharacterCard> cards = new List<CharacterCard>();
    private CharacterCard card;

    private CharacterBase characterBase;

    private CharacterData_Entity characterData;

    private int cardCount;

    private readonly Dictionary<string, Image> roleDictionary = new Dictionary<string, Image>();
    private readonly Dictionary<string, string> positionDictionary
        = new Dictionary<string, string>()
        {
            { "Front", "FRONT" },
            { "Middle", "Middle" },
            { "Back", "Back" }
        };
    private readonly Dictionary<string, (Color color, string text)> attackTypeDictionary
        = new Dictionary<string, (Color color, string text)>
        {
            { "Explosive", (new Color(190.0f / 255.0f, 136.0f / 255.0f, 1.0f / 255.0f), "Æø¹ß") },
            { "Mystic", (new Color(34.0f / 255.0f, 111.0f / 255.0f, 155.0f / 255.0f), "½Åºñ") },
            { "Piercing", (new Color(142.0f / 255.0f, 3.0f / 255.0f, 8.0f / 255.0f), "Æø¹ß") }
        };
    private readonly Dictionary<string, (Color color, string text)> defenceTypeDictionary
        = new Dictionary<string, (Color color, string text)>
    {
        { "Light", (new Color(142.0f / 255.0f, 3.0f / 255.0f, 8.0f / 255.0f), "°æÀå°©") },
        { "Heavy", (new Color(190.0f / 255.0f, 136.0f / 255.0f, 1.0f / 255.0f), "ÁßÀå°©") },
        { "Special", (new Color(34.0f / 255.0f, 111.0f / 255.0f, 155.0f / 255.0f), "Æ¯¼öÀå°©") }
    };
    private readonly Dictionary<string, Image> weaponDictionary = new Dictionary<string, Image>();

    private void Awake()
    {
        InitCards();

        roleDictionary["Attack"] = roles[0];
        roleDictionary["Defence"] = roles[1];
        roleDictionary["Support"] = roles[2];

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
    private void ShowCharacterInfo(int id)
    {
        characterBase = FindAnyObjectByType<CharacterBase>();
        DataManager.Instance.GetCharacterData(id, out characterData);
        int index = id - 1001;
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
    }
}
