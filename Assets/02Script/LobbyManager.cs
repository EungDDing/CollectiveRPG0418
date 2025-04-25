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
        
        for (int i = 0; i < GameManager.Instance.Data.playerCharacters.Count; i++)
        {
            DataManager.Instance.GetCharacterData(GameManager.Instance.Data.playerCharacters[i].characterID, out characterDataEntity);
            Debug.Log(GameManager.Instance.Data.playerCharacters[i].characterID +
                " : " +characterDataEntity.Name + " : " + GameManager.Instance.Data.playerCharacters[i].isOwned);
        }
    }
}
