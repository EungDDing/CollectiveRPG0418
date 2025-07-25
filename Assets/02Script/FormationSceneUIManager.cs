using System.Collections;
using System.Collections.Generic;
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
    private void Awake()
    {
        

        openFormationButton.onClick.AddListener(OnClickOpenFormationButton);
        closeFormationButton.onClick.AddListener(OnClickCloseFormationButton);
    }

    private void OnEnable()
    {
        InitCard();
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
        }
    }

    // button
    
    public void OnClickCloseFormationButton()
    {
        StartCoroutine(CloseFormation());
    }
    private IEnumerator CloseFormation()
    {
        formation.gameObject.LeanScale(Vector3.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);

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

        formation.gameObject.LeanScale(Vector3.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
    }
}
