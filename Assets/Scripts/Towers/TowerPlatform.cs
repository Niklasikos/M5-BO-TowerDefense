using UnityEngine;

public class TowerPlatform : MonoBehaviour, IInteractible
{
    [SerializeField] private GameObject Popup;

    void Start()
    {
        Popup.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OnClicked()
    {
        Popup.SetActive(true);
    }

    public void OnDeselected()
    {
        Popup.SetActive(false);
    }
}
