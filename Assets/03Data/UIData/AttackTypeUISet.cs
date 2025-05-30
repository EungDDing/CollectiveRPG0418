using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackTypeUIData
{
    public string typeKey;
    public Color color;
    public string label;
}

[CreateAssetMenu(menuName = "03Data/AttackTypeUISet")]
public class AttackTypeUISet : ScriptableObject
{
    public List<AttackTypeUIData> attackTypes;
}
