using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int SpawnerID;
    [SerializeField] private Transform[] pathpoints;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    void OnEnable()
    {
        WaveManager.OnWaveStart += WaveStart;
    }

    void OnDisable()
    {
        WaveManager.OnWaveStart -= WaveStart;
    }

    private IEnumerator SpawnEnemy(int EnemySpawnCount, int EnemyType, float interval)
    {
        switch (EnemyType)
        {
            case 1:
                for (int i = 0; i < EnemySpawnCount; i++)
                {
                    yield return new WaitForSeconds(interval);
                    GameObject spawn = Instantiate(enemy1, transform.position, Quaternion.identity);
                    Enemy enemy = spawn.GetComponent<Enemy>();
                    WaveManager.Instance.EnemySpawned();
                    enemy.Init(pathpoints);
                }
                break;

            case 2:

                break;

            case 3:

                break;
        }
    }

    private void WaveStart(int waveCounter, Wave currentWave)
    {
        WaveManager.Instance.SpawnerStarted();
        StartCoroutine(SpawnWave(currentWave));
    }

    private IEnumerator SpawnWave(Wave currentWave)
    {
        foreach (SpawnGroup group in currentWave.spawnGroup)
        {
            if (group.spawnerID != SpawnerID)
                continue;

            yield return StartCoroutine(
                SpawnEnemy(group.enemyCount, group.enemyType, group.spawnEnemyInterval)
            );

        }
        WaveManager.Instance.SpawnerFinished();
    }
}