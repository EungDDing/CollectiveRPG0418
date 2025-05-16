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

    [SerializeField] private Image characterInfo;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI armorText;
    [SerializeField] private TextMeshProUGUI healingText;

    private List<CharacterCard> cards = new List<CharacterCard>();
    private CharacterCard card;
    
    private int cardCount;

    private void Awake()
    {
        InitCards();
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
        }
    }
    private void ClickCharacterCard(int id)
    {
        characterListImage.gameObject.LeanScale(Vector3.zero, 0.3f).setEase(LeanTweenType.easeInOutElastic);
    }
}
