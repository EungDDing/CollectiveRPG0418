using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationSceneManager : SingletonDestory<FormationSceneManager>
{
    private FormationSceneUIManager uiManager;

    protected override void DoAwake()
    {
        base.DoAwake();

        GameManager.Instance.LoadData();
        DataManager.Instance.InitDataManager();
        uiManager = FindObjectOfType<FormationSceneUIManager>();
    }

    private void Start()
    {
        uiManager.RefreshMiniCharacterCards();
    }
}
