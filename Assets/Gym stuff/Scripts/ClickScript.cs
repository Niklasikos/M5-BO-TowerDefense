using UnityEngine;
using UnityEngine.InputSystem;
public class ClickScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private IInteractible interactibleChosen;

    void Update()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame)
            return;

        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);

        if (hit == null)
        {
            if(interactibleChosen != null)
            {
                interactibleChosen.OnDeselected();            
            }
            return;
        }


        IInteractible interactible = hit.GetComponent<IInteractible>();

        if(interactible == null)
            return;

        if(interactibleChosen != null && interactibleChosen != interactible)
        {
            interactibleChosen.OnDeselected();
        }

        interactibleChosen = interactible;
        interactibleChosen.OnClicked();
    }
}
