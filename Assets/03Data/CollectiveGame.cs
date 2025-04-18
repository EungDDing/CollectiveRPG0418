using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class CollectiveGame : ScriptableObject
{
	public List<CharacterData_Entity> CharacterData; // Replace 'EntityType' to an actual type that is serializable.
	public List<LevelData_Entity> LevelData; // Replace 'EntityType' to an actual type that is serializable.
	public List<PlayerLevelData_Entity> PlayerLevelData; // Replace 'EntityType' to an actual type that is serializable.
}
