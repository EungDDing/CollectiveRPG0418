using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DefenceTypeUIData
{
    public string typeKey;
    public Color color;
    public string label;
}

[CreateAssetMenu(menuName = "03Data/DefenceTypeUISet")]
public class DefenceTypeUISet : ScriptableObject
{
    public List<DefenceTypeUIData> defenceTypes;
}
