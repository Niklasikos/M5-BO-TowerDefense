using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
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
    void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
        PausePanel.SetActive(false);
        inputMap = inputActions.FindActionMap("Player");
        Coins += 50;
        UpdateCoinsDisplay();
        UpdateHealthDisplay();
    }

    void Update()
    {
        if(health <= 0 && isAlive)
        {
            isAlive = false;
            Death();
        }
        if(EscapeAction.action.WasPressedThisFrame())
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
        health -= damage;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        Debug.Log("health updates");
        healthCount.text = $"Health: {health}";
    }

    private void Death()
    {
        Time.timeScale = 0f;
        Debug.Log("Player Ded");
    }

    public void Pause()
    {
        if(isPaused)
        {
            isPaused=false;
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
            PauseButton.SetActive(true);
            inputMap.Enable();
        }
        else if(!isPaused)
        {
            isPaused=true;
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            PauseButton.SetActive(false);
            inputMap.Disable();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("gym");
    }
}
