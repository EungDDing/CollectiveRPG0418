using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSceneManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.LoadData();
        DataManager.Instance.InitDataManager();
        Debug.Log(GameManager.Instance.Data.playerID);
    }
}
