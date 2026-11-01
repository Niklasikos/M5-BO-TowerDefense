using UnityEngine;

[System.Serializable]
public class SpawnGroup
{
    [SerializeField] private int spawnerID;
    [SerializeField] private int enemyType;
    [SerializeField] private int enemyCount;
    [SerializeField] private float spawnEnemyInterval = 1f;

    public int SpawnerID {get {return spawnerID;}}
    public int EnemyType {get {return enemyType;}}
    public int EnemyCount {get {return enemyCount;}}
    public float SpawnEnemyInterval {get {return spawnEnemyInterval;}}
}