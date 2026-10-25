using UnityEngine;
using UnityEngine.UI;

public class TriangleButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
    }
}
