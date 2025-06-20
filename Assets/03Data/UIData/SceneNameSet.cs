using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneNameData
{
    public SceneName sceneName;
    public string sceneNameText;
}

[CreateAssetMenu(menuName = "03Data/SceneNameSet")]
public class SceneNameSet : ScriptableObject
{
    public List<SceneNameData> sceneNames;
}
