using UnityEngine;
using TMPro;

public class ClickPopup : MonoBehaviour, IInteractible
{
    private int level = 1;
    [SerializeField] private int MaxLevel = 3;
    [SerializeField] private int[] pricesUpgrades;
    [SerializeField] private GameObject PopUp;
    [SerializeField] private TowerType towerType;
    [SerializeField] TextMeshPro LevelText;
    [SerializeField] TextMeshPro SellText;
    [SerializeField] TextMeshPro UpgradeText;
    [SerializeField] private GameObject Towerpos;
    [SerializeField] private GameObject TowerBuild;
    private bool MaxUpgradeReached = false;
    private LineRenderer lR;


    void Awake()
    {
        LevelText.text = $"{level}";
        UpgradeText.text = $"{pricesUpgrades[level]}$";
        PopUp.SetActive(false);
        lR = GetComponentInParent<LineRenderer>();
    }

    void Update()
    {
        int coinsGettingBackPossible = 0;
        for (int i = 0; i < level && i < pricesUpgrades.Length; i++)
        {
            coinsGettingBackPossible += pricesUpgrades[i];
        }
        SellText.text = $"+{coinsGettingBackPossible * 80 / 100}$";
        if (!MaxUpgradeReached)
        {
            UpgradeText.color = LevelManager.Instance.CoinsCurrently() >= pricesUpgrades[level] ? Color.green : Color.red;
        }
        else
        {
            UpgradeText.color = Color.white;
        }
    }

    public void OnClicked()
    {
        PopUp.SetActive(true);
        lR.enabled = true;
        DrawRadius();
    }

    public void OnDeselected()
    {
        PopUp.SetActive(false);
        lR.enabled = false;
    }

    private void DrawRadius()
    {
        lR.positionCount = 50;
        lR.loop = true;
        lR.useWorldSpace = false;

        for (int i = 0; i < 50; i++)
        {
            float angle = i * 2f * Mathf.PI / 50;

            float x = Mathf.Cos(angle) * transform.parent.GetComponent<CircleCollider2D>().radius;
            float y = Mathf.Sin(angle) * transform.parent.GetComponent<CircleCollider2D>().radius;

            lR.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    public void Upgrade()
    {
        switch (towerType)
        {
            case TowerType.Archer:
                if (MaxUpgradeReached || level >= MaxLevel)
                    break;

                if (LevelManager.Instance.CoinsCurrently() >= pricesUpgrades[level])
                {
                    LevelManager.Instance.RemoveCoins(pricesUpgrades[level]);
                    level++;
                    GetComponentInParent<ArcherTower>().LevelStats(level);
                    LevelText.text = $"{level}";
                    if (level >= MaxLevel)
                    {
                        MaxUpgradeReached = true;
                        UpgradeText.text = "Max";
                    }
                    else
                    {
                        UpgradeText.text = $"{pricesUpgrades[level]}$";
                    }
                }
                break;
                // komt
        }
    }

    public void Sell()
    {
        Destroy(Towerpos);
        Instantiate(TowerBuild, Towerpos.transform.position, Quaternion.identity);
        int coinsGettingBack = 0;
        for (int i = 0; i < level && i < pricesUpgrades.Length; i++)
        {
            coinsGettingBack += pricesUpgrades[i];
        }
        LevelManager.Instance.AddCoins(coinsGettingBack * 80 / 100);
    }

}
