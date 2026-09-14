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

    public void ButtonClicked(PopUpButton.TowerType towerType)
    {
        switch(towerType)
        {
            case PopUpButton.TowerType.Archer:
                if(LevelManager.Instance.CoinsCurrently() >= ArcherPrice)
                {
                    Instantiate(ArcherTower, TowerPos.transform.position, quaternion.identity);
                    LevelManager.Instance.RemoveCoins(ArcherPrice);
                    Destroy(TowerPos);
                } 
                break;
            case PopUpButton.TowerType.Mage:
                Debug.Log("Mage");
                break;
            case PopUpButton.TowerType.Canon:
                Debug.Log("Canon");
                break;
            default:
                Debug.Log("whopsie pupsie");
                break;
        }
    }
}
