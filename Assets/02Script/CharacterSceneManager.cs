using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSceneManager : SingletonDestory<CharacterSceneManager>
{
    private CharacterSceneUIManager uiManager;

    [SerializeField] private Transform characterPosition;

    protected override void DoAwake()
    {
        base.DoAwake();

        GameManager.Instance.LoadData();
        DataManager.Instance.InitDataManager();
        Debug.Log(GameManager.Instance.Data.playerID);
        uiManager = FindObjectOfType<CharacterSceneUIManager>();
    }
    private void Start()
    {
        uiManager.RefreshCharacterListUI();
    }
    public void ShowCharacter(int id)
    {
        CharacterBase character = Resources.Load<CharacterBase>($"Characters/{id}");
        Instantiate(character, characterPosition.position, Quaternion.Euler(0.0f, 160.0f, 0.0f));
    }
}
