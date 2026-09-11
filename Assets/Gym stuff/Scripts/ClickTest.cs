using UnityEngine;

public class ClickTest : MonoBehaviour
{
    [SerializeField] private GameObject triangle;

    void Start()
    {
        triangle.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OnClicked()
    {
        triangle.SetActive(true);
    }

    public void OnDeselected()
    {
        triangle.SetActive(false);
    }
}
