using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class BuilderPopup : MonoBehaviour
{
    [SerializeField] private GameObject TowerPos;
    [SerializeField] private GameObject ArcherTower;
    [SerializeField] private GameObject MageTower;
    [SerializeField] private GameObject CanonTower;

    [SerializeField] private TextMeshPro ArchText;
    [SerializeField] private TextMeshPro MageText;
    [SerializeField] private TextMeshPro CanonText;

    [SerializeField] private int ArcherPrice;
    [SerializeField] private int MagePrice;
    [SerializeField] private int CanonPrice;

    void Update()
    {
        ArchText.color = LevelManager.Instance.CoinsCurrently() >= ArcherPrice ? Color.green : Color.red;
        MageText.color = LevelManager.Instance.CoinsCurrently() >= MagePrice ? Color.green : Color.red;
        CanonText.color = LevelManager.Instance.CoinsCurrently() >= CanonPrice ? Color.green : Color.red;
    }

    public void ButtonClicked(TowerType towerType)
    {
        switch(towerType)
        {
            case TowerType.Archer:
                if(LevelManager.Instance.CoinsCurrently() >= ArcherPrice)
                {
                    Destroy(TowerPos);                 
                    Instantiate(ArcherTower, TowerPos.transform.position, quaternion.identity);
                    LevelManager.Instance.RemoveCoins(ArcherPrice);
                } 
                break;
            case TowerType.Mage:
                Debug.Log("Mage");
                // if(LevelManager.Instance.CoinsCurrently() >= MagePrice)
                // {
                //     Instantiate(MageTower, TowerPos.transform.position, quaternion.identity);
                //     LevelManager.Instance.RemoveCoins(MagePrice);
                //     Destroy(TowerPos);
                // }
                break;
            case TowerType.Canon:
                Debug.Log("Canon");
                // if(LevelManager.Instance.CoinsCurrently() >= CanonPrice)
                // {
                //     Instantiate(CanonTower, TowerPos.transform.position, quaternion.identity);
                //     LevelManager.Instance.RemoveCoins(CanonPrice);
                //     Destroy(TowerPos);
                // }
                break;
            default:
                Debug.Log("whopsie pupsie");
                break;
        }
    }
}
