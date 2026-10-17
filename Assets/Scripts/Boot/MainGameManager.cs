using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance {get; private set;}
    public int[] stats = new int[] {0, 0, 0, 0};
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
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
}
