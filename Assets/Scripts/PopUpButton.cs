using UnityEngine;

public class PopUpButton : MonoBehaviour, IInteractible
{
    public enum TowerType
    {
        Archer,
        Mage,
        Canon
    }
    [SerializeField] private TowerType towerType;
    private BuilderPopup parent;
    void Awake()
    {
        parent = GetComponentInParent<BuilderPopup>();
    }

    public void OnClicked()
    {
        parent.ButtonClicked(towerType);
    }

    public void OnDeselected()
    {
        // niks
    }
}
