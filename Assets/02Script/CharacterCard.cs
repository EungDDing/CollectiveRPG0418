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
    
    public void DrawCharacterCard(int characterID)
    {
        if (DataManager.Instance.GetCharacterData(characterID, out CharacterData_Entity characterData))
        {
            image.sprite = Resources.Load<Sprite>(characterData.CharacterImage);
            image.enabled = true;
            nameText.text = characterData.Name.ToString();
            Debug.Log(characterData.Name);
        }
    }
}
