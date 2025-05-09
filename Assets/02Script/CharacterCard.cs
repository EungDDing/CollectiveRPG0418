using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI nameText;

    private int id;

    public int ID { get => ID; }

    public delegate void CharacterID(int id);
    public event CharacterID OnClickCharacterCard;

    public void DrawCharacterCard(int index)
    {
        id = index + 1001;
        if (DataManager.Instance.GetCharacterData(id, out CharacterData_Entity characterData))
        {
            levelText.text = "Lv." + GameManager.Instance.Data.playerCharacters[index].level.ToString();
            image.sprite = Resources.Load<Sprite>(characterData.CharacterImage);
            image.enabled = true;
            nameText.text = characterData.Name.ToString();
            Debug.Log(characterData.Name);
        }
    }
    public void ClickCard()
    {
        Debug.Log("call event" + id);
        OnClickCharacterCard?.Invoke(id);
    }
}
