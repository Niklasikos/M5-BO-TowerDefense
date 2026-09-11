using UnityEngine;
using UnityEngine.InputSystem;
public class ClickScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private ClickTest clickTestSelected;

    void Update()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame)
            return;

        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);

        if (hit == null)
            return;


        ClickTest clickTest = hit.GetComponent<ClickTest>();

        if(clickTest == null)
            return;

        if(clickTestSelected != null && clickTestSelected != clickTest)
        {
            clickTestSelected.OnDeselected();
        }

        clickTestSelected = clickTest;
        clickTestSelected.OnClicked();
    }
}
