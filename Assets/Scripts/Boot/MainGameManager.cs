using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance { get; private set; }
    private bool[] LevelsBeaten = new bool[] { false, false, false, false, false };
    private int[] stats = new int[] { 0, 0, 0, 0 };
    [SerializeField] private string SaveFileName1;
    [SerializeField] private string SaveFileName2;
    private string SaveFilePath1;
    private string SaveFilePath2;
    void Awake()
    {
        SaveFilePath1 = Path.Combine(Application.persistentDataPath, SaveFileName1);
        SaveFilePath2 = Path.Combine(Application.persistentDataPath, SaveFileName2);

        Application.targetFrameRate = 60;
        Application.runInBackground = true;
        QualitySettings.vSyncCount = 1;
    }
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (File.Exists(SaveFilePath1) == true)
        {
            LevelsBeaten = Array.ConvertAll(File.ReadAllLines(SaveFilePath1), bool.Parse);
        }

        if (File.Exists(SaveFilePath1) == false)
        {
            File.WriteAllLines(SaveFilePath1, Array.ConvertAll(LevelsBeaten, b => b.ToString()));
        }

        if (File.Exists(SaveFilePath2) == true)
        {
            stats = Array.ConvertAll(File.ReadAllLines(SaveFilePath2), int.Parse);
        }

        if (File.Exists(SaveFilePath2) == false)
        {
            File.WriteAllLines(SaveFilePath2, Array.ConvertAll(stats, i => i.ToString()));
        }

        SceneManager.LoadScene("Main Menu");
    }

    void Update()
    {

    }

    public bool GetBool(int level)
    {
        return LevelsBeaten[level - 1];
    }

    public void SetBool(int level)
    {
        LevelsBeaten[level - 1] = true;
        UpdateFiles();
    }

    public void ResetSave()
    {
        for (int i = 0; i < LevelsBeaten.Length; i++)
        {
            LevelsBeaten[i] = false;
        }
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = 0;
        }
        UpdateFiles();
    }

    public void UpdateFiles()
    {
        File.WriteAllLines(SaveFilePath1, Array.ConvertAll(LevelsBeaten, level => level.ToString()));
        File.WriteAllLines(SaveFilePath2, Array.ConvertAll(stats, stat => stat.ToString()));
    }


}
