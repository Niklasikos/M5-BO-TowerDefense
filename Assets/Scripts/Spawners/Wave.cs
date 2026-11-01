using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] private SpawnGroup[] spawnGroup;

    public SpawnGroup[] GetSpawnGroups()
    {
        return spawnGroup;
    }
}