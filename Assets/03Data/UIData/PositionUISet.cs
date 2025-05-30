using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PositionUIData
{
    public string positionKey;
    public string label;
}

[CreateAssetMenu(menuName = "03Data/PositionUISet")]
public class PositionUISet : ScriptableObject
{
    public List<PositionUIData> positions;
}
