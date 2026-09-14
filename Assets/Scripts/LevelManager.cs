using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private TextMeshProUGUI coinsCount;
    [SerializeField] private TextMeshProUGUI healthCount;
    [SerializeField] private int Coins;
    [SerializeField] private int health;
    [SerializeField] private bool isAlive = true;
    void Awake()
    {
        Instance = this;
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
}
