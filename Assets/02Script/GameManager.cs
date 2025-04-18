using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerCharacterData
{
    public int characterID;
    public int level;
    public int exp;
    
}
[System.Serializable]
public class PlayerData
{
    public string playerID;
    public int level;
    public int currentEXP;
    public int gold;
    public int gem;
    public int energy;
}
public class GameManager : Singleton<GameManager>
{

}
