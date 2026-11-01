using UnityEngine;
using UnityEngine.UI;

public class ScrollingTexture : MonoBehaviour
{
    private RawImage image;
    [SerializeField] private Vector2 scrollSpeed = new Vector2(0.1f, 0f);
    private Vector2 offset;

    void Awake()
    {
        image = GetComponent<RawImage>();
    }
    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        image.uvRect = new Rect(offset, Vector2.one);
    }
}