using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour, IInteractible
{
    [SerializeField] private int Level;
    [SerializeField] private Sprite BannerSpriteBlue;
    [SerializeField] private Sprite BannerSpriteRed;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = true ? BannerSpriteBlue : BannerSpriteRed;
    }

    void Update()
    {
        
    }

    public void OnClicked()
    {
        Debug.Log(Level);
        LevelSelectManager.Instance.SelectLevel(Level);
    }

    public void OnDeselected()
    {
        
    }
}
