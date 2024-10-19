using UnityEngine;

[CreateAssetMenu(fileName = "LevelPrefabManager", menuName = "ScriptableObjects/LevelPrefabManager", order = 2)]
public class LevelPrefabManager : ScriptableObject
{
    public GameObject[] levelPrefabList;
}