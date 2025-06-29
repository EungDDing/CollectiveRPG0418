using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData_Entity
{
    public int ID;
    public string Name;
    public int Rank;
    public string Weapon;
    public string Role;
    public string Skill;
    public int AttackRange;
    public string AttackType;
    public string DefenceType;
    public string Position;
    public string CharacterImage;
}

[System.Serializable]
public class LevelData_Entity
{
    public int Level;
    public int HP;
    public int Armor;
    public int Attack;
    public int Healing;
    public int Exp;
}

[System.Serializable]
public class PlayerLevelData_Entity
{
    public int PlayerLevel;
    public int MaxEnergy;
    public int PlayerExp;
}

[System.Serializable]
public class MissionData_Entity
{
    public int MissionID;
    public int Mission;
    public int Stage;
}

[System.Serializable]
public class SkillData_Entity
{
    public int ID;
    public string Skill;
    public int SkillCost;
    public int SkillRange;
    public string SkillInfo;
}