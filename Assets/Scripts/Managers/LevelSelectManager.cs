using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager Instance { get; private set; }
    private int LevelSelected = 1;

    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI DifficultyText;
    [SerializeField] private TextMeshProUGUI EnemyCount1;
    [SerializeField] private TextMeshProUGUI EnemyCount2;
    [SerializeField] private TextMeshProUGUI EnemyCount3;
    [SerializeField] private int[] EnemyCounter1;
    [SerializeField] private int[] EnemyCounter2;
    [SerializeField] private int[] EnemyCounter3;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] InputActionReference EscapeAction;
    [SerializeField] private GameObject transitionerGO;
    [SerializeField] private Image transitioner;
    private bool isPaused = false;

    void OnEnable()
    {
        EscapeAction.action.Enable();
    }

    void OnDisable()
    {
        EscapeAction.action.Disable();
    }

    void Awake()
    {
        Instance = this;
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
    }

    void Start()
    {
        transitioner.CrossFadeAlpha(0f, 1f, false);
        Invoke(nameof(SetInActive), 1f);
        Time.timeScale = 1f;
        SelectLevel(LevelSelected);
    }

    void Update()
    {
        if (EscapeAction.action.WasPressedThisFrame())
        {
            Pause();
        }
    }

    public void StartLevel()
    {
        SetActive();
        transitioner.CrossFadeAlpha(1f, 1f, false);
        Invoke(nameof(LoadLevel), 1f);
    }

    private void LoadLevel()
    {
        switch (LevelSelected)
        {
            case 1:
                SceneManager.LoadScene("Level 1");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
            case 4:
                SceneManager.LoadScene("Level 4");
                break;
            case 5:
                SceneManager.LoadScene("Level 5");
                break;
        }
    }

    public void SelectLevel(int level)
    {
        switch (level)
        {
            case 1:
                LevelSelected = level;
                LevelText.text = "Level 1";
                DifficultyText.text = "Difficulty: 1/5";
                EnemyCount1.text = $"{EnemyCounter1[level]}";
                EnemyCount2.text = $"{EnemyCounter2[level]}";
                EnemyCount3.text = $"{EnemyCounter3[level]}";
                break;
            case 2:
                LevelSelected = level;
                LevelText.text = "Level 2";
                DifficultyText.text = "Difficulty: 2/5";
                EnemyCount1.text = $"{EnemyCounter1[level]}";
                EnemyCount2.text = $"{EnemyCounter2[level]}";
                EnemyCount3.text = $"{EnemyCounter3[level]}";
                break;
            case 3:
                LevelSelected = level;
                LevelText.text = "Level 3";
                DifficultyText.text = "Difficulty: 3/5";
                EnemyCount1.text = $"{EnemyCounter1[level]}";
                EnemyCount2.text = $"{EnemyCounter2[level]}";
                EnemyCount3.text = $"{EnemyCounter3[level]}";
                break;
            case 4:
                LevelSelected = level;
                LevelText.text = "Level 4";
                DifficultyText.text = "Difficulty: 4/5";
                EnemyCount1.text = $"{EnemyCounter1[level]}";
                EnemyCount2.text = $"{EnemyCounter2[level]}";
                EnemyCount3.text = $"{EnemyCounter3[level]}";
                break;
            case 5:
                LevelSelected = level;
                LevelText.text = "Level 5";
                DifficultyText.text = "Difficulty: 5/5";
                EnemyCount1.text = $"{EnemyCounter1[level]}";
                EnemyCount2.text = $"{EnemyCounter2[level]}";
                EnemyCount3.text = $"{EnemyCounter3[level]}";
                break;
        }
    }

    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            PausePanel.SetActive(false);
            PauseButton.SetActive(true);
        }
        else if (!isPaused)
        {
            isPaused = true;
            PausePanel.SetActive(true);
            PauseButton.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SetActive();
        transitioner.CrossFadeAlpha(1f, 1f, false);
        Invoke(nameof(LoadMainMenu), 1f);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");        
    }

    private void SetInActive()
    {
        transitionerGO.SetActive(false);
    }

    private void SetActive()
    {
        transitionerGO.SetActive(true);
    }
}
