using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public CharacterData_Entity charaterData;
    public LevelData_Entity levelData;

    private int level;
    private float maxHP;

    private float currentHP;

    public int Level 
    {
        get => level;
        set => level = value;
    }
    public void InitCharacter(int characterID)
    {
        DataManager.Instance.GetCharacterData(characterID, out charaterData);
        DataManager.Instance.GetLevelData(Level, out levelData);
    }
    public float CalculateDamage(float takedDamage)
    {
        float finalDamage;

        finalDamage = takedDamage;
        return finalDamage;
    }
    public void TakeDamage(float takedDamage, GameObject attacker)
    {

    }
}
