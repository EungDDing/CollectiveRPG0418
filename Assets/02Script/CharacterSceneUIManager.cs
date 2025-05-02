using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSceneUIManager : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private RectTransform contentTransform;

    private List<CharacterCard> cards = new List<CharacterCard>();
    private CharacterCard card;

    private int cardCount;

    private void Awake()
    {
        InitCards();
    }
    private void InitCards()
    {
        cardCount = 10;
        for (int i = 0; i < cardCount; i++)
        {
            if (Instantiate(cardPrefab, contentTransform).TryGetComponent<CharacterCard>(out card))
            {
                cards.Add(card);
                Debug.Log("카드 추가");
            }
        }
    }
    public void RefreshCharacterListUI()
    {
        for (int i = 0; i < cardCount; i++)
        {
            Debug.Log("카드 Index" + (i + 1001));
            cards[i].DrawCharacterCard(i + 1001);
        }
    }
}
