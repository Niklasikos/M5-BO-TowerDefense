using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance {get; private set;}
    private bool[] LevelsBeaten = new bool[] {false, false, false, false, false};
    public int[] stats = new int[] {0, 0, 0, 0};
    [SerializeField] private string SaveFileName1;
    [SerializeField] private string SaveFileName2;
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        SaveFile();
    }
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Main Menu");
    }

    void Update()
    {
        
    }

    public bool GetBool(int level)
    {
        Math.Clamp(level, 1, 5);
        return LevelsBeaten[level];
    }

    public void SaveFile()
    {
        File.WriteAllLines(SaveFileName1, Array.ConvertAll(LevelsBeaten, level => level.ToString()));
    }

    public void ReadFile()
    {
        if (!File.Exists(SaveFileName1))
        {   
            Debug.Log("File not Existing");
            return;
        }

        string[] savedLevels = File.ReadAllLines(SaveFileName1);
        for (int i = 0; i < savedLevels.Length && i < LevelsBeaten.Length; i++)
        {
            if (bool.TryParse(savedLevels[i], out bool levelBeaten))
                LevelsBeaten[i] = levelBeaten;
        }
    }
}
