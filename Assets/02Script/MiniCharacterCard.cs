using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniCharacterCard : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Image frame;
    [SerializeField] private TextMeshProUGUI nameText;

    private int id;

    public delegate void CharacterID(int id);
    public event CharacterID OnClickMiniCharacterCard;

    [SerializeField] private AttackTypeUISet attackTypeUISet;
    private readonly Dictionary<string, (Color color, string text)> attackTypeDictionary
        = new Dictionary<string, (Color color, string text)>();

    private void Awake()
    {
        foreach (AttackTypeUIData data in attackTypeUISet.attackTypes)
        {
            attackTypeDictionary[data.typeKey] = (data.color, data.label);
        }
    }
    public void DrawMiniCharacterCard(int index)
    {
        id = index + 1001;
        if (DataManager.Instance.GetCharacterData(id, out CharacterData_Entity characterData))
        {
            characterImage.sprite = Resources.Load<Sprite>(characterData.CharacterImage);
            characterImage.enabled = true;

            if (attackTypeDictionary.TryGetValue(characterData.AttackType, out (Color color, string text) attackType))
            {
                frame.color = attackType.color;
            }

            nameText.text = characterData.Name.ToString();
        }
    }
    
    public void ClickMiniCard()
    {
        Debug.Log("call event(mini card)" + id);
        OnClickMiniCharacterCard?.Invoke(id);
    }
}
