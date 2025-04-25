using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public CharacterData_Entity characterData;
    public LevelData_Entity levelData;

    public CharacterData_Entity CharacterData { get => characterData; }
    public LevelData_Entity LevelData { get => levelData; }
    private int characterID;
    private int level;

    private float maxHP;
    private int armor;
    private int attack;
    private int exp;

    private void Start()
    {
        SetCharacterID();
        Debug.Log(characterID);
        InitCharacter(characterID);
        Debug.Log(CharacterData.Name);
        GetCharacterLevelData(1);
        SetCharacterData();
        Debug.Log(MaxHP + " " + Armor + " " + Attack);
    }
    public int CharacterID
    {
        get => characterID;
        set => characterID = value;
    }
    public int Level
    {
        get => level;
        set => level = value;
    }
    public float MaxHP
    {
        get => maxHP;
        set => maxHP = value;
    }
    public int Armor
    {
        get => armor;
        set => armor = value;
    }
    public int Attack
    {
        get => attack;
        set => attack = value;
    }
    public int Exp
    {
        get => exp;
        set => exp = value;
    }
    public void InitCharacter(int characterID)
    {
        DataManager.Instance.GetCharacterData(characterID, out characterData);
    }
    public void GetCharacterLevelData(int level)
    {
        DataManager.Instance.GetLevelData(level, out levelData);
    }
    public abstract void SetCharacterID();
    public void SetCharacterData()
    {
        if (characterData.Role == "Defence")
        {
            armor = levelData.Armor + 5;
        }
        else
        {
            armor = levelData.Armor;
        }

        if (characterData.Role == "Attack")
        {
            attack = levelData.Attack + 10;
        }
        else
        {
            attack = levelData.Attack;
        }

        maxHP = levelData.HP;
        exp = levelData.Exp;
    }
}
