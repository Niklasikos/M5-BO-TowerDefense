using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] private SpawnGroup[] spawnGroup;

    public SpawnGroup[] SpawnGroup {get {return spawnGroup;}}
}