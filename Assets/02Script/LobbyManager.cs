using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private CharacterData_Entity characterDataEntity;
    private void Start()
    {
        GameManager.Instance.LoadData();
        DataManager.Instance.InitDataManager();
        Debug.Log(GameManager.Instance.Data.playerID);
    }
    public void CharacterButton()
    {
        Debug.Log("»£√‚");

        GameManager.Instance.AsyncLoadNextScene(SceneName.CharacterScene);
    }
}
