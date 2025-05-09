using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSceneManager : SingletonDestory<CharacterSceneManager>
{
    private CharacterSceneUIManager uiManager;
    private CharacterCard card;

    [SerializeField] private Transform characterPosition;

    protected override void DoAwake()
    {
        base.DoAwake();

        GameManager.Instance.LoadData();
        DataManager.Instance.InitDataManager();
        Debug.Log(GameManager.Instance.Data.playerID);
        uiManager = FindObjectOfType<CharacterSceneUIManager>();
        card = FindObjectOfType<CharacterCard>();
    }
    private void Start()
    {
        uiManager.RefreshCharacterListUI();
    }
    public void ShowCharacter(int id)
    {
        CharacterBase character = Resources.Load<CharacterBase>($"Characters/{id}");
        Instantiate(character, characterPosition.position, Quaternion.identity);
    }
}
