using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private bool hasPlayerInfo;
    private string newID;

    private void Start()
    {
        InitTitleScene();
        DataManager.Instance.InitDataManager();
    }

    private void InitTitleScene()
    {
        if (GameManager.Instance.GetPlayerData())
        {
            hasPlayerInfo = true;
            Debug.Log("hasPlayerInfo");
        }
        else
        {
            hasPlayerInfo = false;
            Debug.Log("no playerInfo");
        }
    }

    public void EnterButton()
    {
        if (hasPlayerInfo)
        {
            GameManager.Instance.AsyncLoadNextScene(SceneName.LobbyScene);
        }
    }
    public void DeleteButton()
    {
        if (!hasPlayerInfo)
        {
            Debug.Log("no playerInfo");
        }
        GameManager.Instance.DeleteData();
        InitTitleScene();
    }
    public void IDInputField(string inputID)
    {
        newID = inputID;
        Debug.Log(newID);
    }

    public void ApplyButton()
    {
        if (newID != null && newID.Length >= 2)
        {
            GameManager.Instance.CreatePlayerData(newID);
            GameManager.Instance.SaveData();
            InitTitleScene();
        }
        else
        {
            // error Message
        }
    }
}
