
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject DeathUI;
    [SerializeField] private Image Heart;
    [SerializeField] private Sprite Heart100;
    [SerializeField] private Sprite Heart80;
    [SerializeField] private Sprite Heart60;
    [SerializeField] private Sprite Heart40;
    [SerializeField] private Sprite Heart20;
    [SerializeField] private Sprite Heart00;
    [SerializeField] private TextMeshProUGUI coinsCount;
    [SerializeField] private TextMeshProUGUI healthCount;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private int Coins;
    [SerializeField] private int health;
    [SerializeField] private bool isAlive = true;
    private bool isPaused = false;

    [SerializeField] InputActionReference EscapeAction;
    [SerializeField] InputActionAsset inputActions;
    private InputActionMap inputMap;

    void OnEnable()
    {
        inputActions.Enable();
        EscapeAction.action.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
        EscapeAction.action.Disable();
    }
    void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
        PausePanel.SetActive(false);
        WinUI.SetActive(false);
        DeathUI.SetActive(false);
        inputMap = inputActions.FindActionMap("Player");
        Coins += 50;
        UpdateCoinsDisplay();
        UpdateHealthDisplay();
    }

    void Update()
    {
        if (EscapeAction.action.WasPressedThisFrame())
        {
            Pause();
        }
    }

    public void AddCoins(int coins)
    {
        Coins += coins;
        UpdateCoinsDisplay();
    }

    public void RemoveCoins(int coins)
    {
        Coins -= coins;
        UpdateCoinsDisplay();
    }

    private void UpdateCoinsDisplay()
    {
        Debug.Log("Coins updated");
        coinsCount.text = $"Coins: {Coins}";
    }

    public int CoinsCurrently()
    {
        return Coins;
    }

    public void GetDamage(int damage)
    {
        if (!isAlive)
            return;

        health -= damage;
        UpdateHealthDisplay();
        UpdateHeart();

        if (health <= 0)
        {
            isAlive = false;
            Death();
        }
    }

    public bool GetAlive()
    {
        return isAlive;
    }

    private void UpdateHealthDisplay()
    {
        Debug.Log("health updates");
        healthCount.text = $"Health: {health}";
    }

    private void UpdateHeart()
    {
        if (health <= 0)
            Heart.sprite = Heart00;
        else if (health <= 20)
            Heart.sprite = Heart20;
        else if (health <= 40)
            Heart.sprite = Heart40;
        else if (health <= 60)
            Heart.sprite = Heart60;
        else if (health <= 80)
            Heart.sprite = Heart80;
        else
            Heart.sprite = Heart100;
    }

    private void Death()
    {
        Time.timeScale = 0f;
        inputActions.Disable();
        EscapeAction.action.Disable();
        DeathUI.SetActive(true);
        Debug.Log("Player Ded");
    }

    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
            PauseButton.SetActive(true);
            inputMap.Enable();
        }
        else if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            PauseButton.SetActive(false);
            inputMap.Disable();
        }
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void WonLevel()
    {
        OnDisable();
        Time.timeScale = 0f;
        WinUI.SetActive(true);
    }
}
