using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public static event Action<int, Wave> OnWaveStart;
    private int enemyCount = 0;
    private int spawnerActive = 0;
    private int WaveCounter = 0;
    private int MaxWaves;
    [SerializeField] TextMeshProUGUI wavetext;
    [SerializeField] GameObject Button;
    [SerializeField] private Wave[] waves;
    private bool Won = false;

    void Awake()
    {
        Instance = this;
        MaxWaves = waves.Length;
        wavetext.text = $"{WaveCounter}/{MaxWaves}";
    }

    public void WaveStart()
    {
        if (WaveCounter >= MaxWaves)
        {
            Debug.Log("Max wave reached");
            checkWin();
            return;
        }
        Button.SetActive(false);
        OnWaveStart?.Invoke(WaveCounter, waves[WaveCounter]);
        WaveCounter++;
        wavetext.text = $"{WaveCounter}/{MaxWaves}";
        if (WaveCounter < MaxWaves)
        {
            StartCoroutine(Wait(10));
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Button.SetActive(true);
    }

    private void checkWin()
    {
        if  (Won)
            return;

        Debug.Log($"Enemies: {enemyCount} | Active Spawners: {spawnerActive} | Waves: {WaveCounter}/{MaxWaves}");
        if (enemyCount == 0 && spawnerActive == 0 && WaveCounter >= MaxWaves && LevelManager.Instance.GetAlive())
        {
            Won = true;
            Debug.Log("Player Won");
            LevelManager.Instance.WonLevel();
        }
        else
        {
            Debug.Log("nuh uh");
        }

    }

    public void SpawnerStarted()
    {
        spawnerActive++;
    }

    public void SpawnerFinished()
    {
        spawnerActive--;
        checkWin();
    }

    public void EnemySpawned()
    {
        enemyCount++;
    }

    public void EnemyDead()
    {
        enemyCount--;
        checkWin();
    }
}
