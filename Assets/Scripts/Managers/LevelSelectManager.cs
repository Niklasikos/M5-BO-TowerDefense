using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager Instance {get; private set;}
    private int LevelSelected = 1;

    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI DifficultyText;

    void Awake()
    {
        Instance = this;
    }

    public void StartLevel()
    {
        switch(LevelSelected)
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
            break;
            case 2:
                LevelSelected = level;
                LevelText.text = "Level 2";
                DifficultyText.text = "Difficulty: 2/5";
            break;
            case 3:
                LevelSelected = level;
                LevelText.text = "Level 3";
                DifficultyText.text = "Difficulty: 3/5";
            break;
            case 4:
                LevelSelected = level;
                LevelText.text = "Level 4";
                DifficultyText.text = "Difficulty: 4/5";
            break;
            case 5:
                LevelSelected = level;
                LevelText.text = "Level 5";
                DifficultyText.text = "Difficulty: 5/5";
            break;
        }
    }
}
