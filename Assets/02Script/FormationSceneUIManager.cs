using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormationSceneUIManager : MonoBehaviour
{
    // scroll view
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject miniCardPrefab;
    [SerializeField] private RectTransform contentTransform;

    private List<MiniCharacterCard> miniCards = new List<MiniCharacterCard>();
    private MiniCharacterCard miniCard;

    private int cardCount;

    // formation window
    [SerializeField] private Image formation;
    [SerializeField] private Image backgroundImage;

    [SerializeField] private Button closeFormationButton;
    [SerializeField] private Button openFormationButton;

    // formation window - character information
    private CharacterData_Entity characterData;
    private SkillData_Entity skillData;

    private int characterId;

    [SerializeField] private Image characterImage;
    [SerializeField] private Image frame;
    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField] private Image characterInfo;

    [SerializeField] private List<Image> roles;
    [SerializeField] private TextMeshProUGUI positionText;
    [SerializeField] private Image attackTypeImage;
    [SerializeField] private TextMeshProUGUI attackTypeText;
    [SerializeField] private Image defenceTypeImage;
    [SerializeField] private TextMeshProUGUI defenceTypeText;

    [SerializeField] private Image skillImageBackground;
    [SerializeField] private TextMeshProUGUI skillNameText;
    [SerializeField] private TextMeshProUGUI skillInfoText;
    [SerializeField] private TextMeshProUGUI skillCostText;

    private readonly Dictionary<string, Image> roleDictionary = new Dictionary<string, Image>();

    [SerializeField] private PositionUISet positionUISet;
    private readonly Dictionary<string, string> positionDictionary = new Dictionary<string, string>();

    [SerializeField] private AttackTypeUISet attackTypeUISet;
    private readonly Dictionary<string, (Color color, string text)> attackTypeDictionary
        = new Dictionary<string, (Color color, string text)>();

    [SerializeField] private DefenceTypeUISet defenceTypeUISet;
    private readonly Dictionary<string, (Color color, string text)> defenceTypeDictionary
        = new Dictionary<string, (Color color, string text)>();

    private void Awake()
    {
        InitCard();

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

        // onClick
        openFormationButton.onClick.AddListener(OnClickOpenFormationButton);
        closeFormationButton.onClick.AddListener(OnClickCloseFormationButton);
    }

    // character card
    private void InitCard()
    {
        cardCount = 10;
        for (int i = 0; i < cardCount; i++)
        {
            if (Instantiate(miniCardPrefab, contentTransform).TryGetComponent<MiniCharacterCard>(out miniCard))
            {
                miniCards.Add(miniCard);
            }
        }

    }
    public void RefreshMiniCharacterCards()
    {
        for (int i = 0; i < cardCount; i++)
        {
            miniCards[i].DrawMiniCharacterCard(i);

            // set event
            miniCards[i].OnClickMiniCharacterCard -= showCharacterInfo;
            miniCards[i].OnClickMiniCharacterCard += showCharacterInfo;

        }
    }

    // character info
    private void showCharacterInfo(int id)
    {
        DataManager.Instance.GetCharacterData(id, out characterData);
        DataManager.Instance.GetSkillData(id, out skillData);

        characterId = id;

        StartCoroutine(ShowInfo(id));
    }
    private IEnumerator ShowInfo(int id)
    {
        
        characterInfo.gameObject.SetActive(true);

        yield return null;

        characterImage.sprite = Resources.Load<Sprite>(characterData.CharacterImage);
        characterImage.enabled = true;

        if (attackTypeDictionary.TryGetValue(characterData.AttackType, out (Color color, string text) attackType))
        {
            frame.color = attackType.color;

            attackTypeImage.color = attackType.color;
            attackTypeText.text = attackType.text;

            skillImageBackground.color = attackType.color;
        }

        nameText.text = characterData.Name.ToString();

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

        if (defenceTypeDictionary.TryGetValue(characterData.DefenceType, out (Color color, string text) defenceType))
        {
            defenceTypeImage.color = defenceType.color;
            defenceTypeText.text = defenceType.text;
        }

        skillNameText.text = skillData.Skill;
        skillInfoText.text = skillData.SkillInfo;
        skillCostText.text = "COST : " + skillData.SkillCost.ToString();
    }
    // button
    
    public void OnClickCloseFormationButton()
    {
        StartCoroutine(CloseFormation());
    }
    private IEnumerator CloseFormation()
    {
        formation.gameObject.LeanScale(Vector3.zero, 0.4f).setEase(LeanTweenType.easeInElastic);

        yield return null;

        backgroundImage.gameObject.SetActive(false);
    }
    public void OnClickOpenFormationButton()
    {
        StartCoroutine(OpenFormation());
    }
    private IEnumerator OpenFormation()
    {
        backgroundImage.gameObject.SetActive(true);

        yield return null;

        formation.gameObject.LeanScale(Vector3.one, 0.4f).setEase(LeanTweenType.easeInElastic);
    }
    
}
