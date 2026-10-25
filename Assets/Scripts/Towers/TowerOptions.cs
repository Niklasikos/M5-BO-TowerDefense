using UnityEngine;

public enum TowerOption
{
    Upgrade,
    Sell
}
public class TowerOptions : MonoBehaviour, IInteractible
{
    [SerializeField] private TowerOption towerOption;

    public void OnClicked()
    {
        switch (towerOption)
        {
            case TowerOption.Upgrade:
                transform.parent.parent.GetComponentInChildren<ClickPopup>().Upgrade();
            break;

            case TowerOption.Sell:
                transform.parent.parent.GetComponentInChildren<ClickPopup>().Sell();
            break;
        }
    }

    public void OnDeselected()
    {
        
    }
}
