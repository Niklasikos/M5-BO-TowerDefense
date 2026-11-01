using UnityEngine;

[System.Serializable]
public class SpawnGroup
{
    [SerializeField] private int spawnerID;
    [SerializeField] private int enemyType;
    [SerializeField] private int enemyCount;
    [SerializeField] private float spawnEnemyInterval = 1f;

    public int GetSpawnerID()
    {
        return spawnerID;
    }

    public int GetEnemyType()
    {
        return enemyType;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public float GetSpawnEnemyInterval()
    {
        return spawnEnemyInterval;
    }
}