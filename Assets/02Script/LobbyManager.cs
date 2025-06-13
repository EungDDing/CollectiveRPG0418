using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private CharacterData_Entity characterDataEntity;
    private void Start()
    {
        GameManager.Instance.GetPlayerData();
        DataManager.Instance.InitDataManager();
    }
    
}
