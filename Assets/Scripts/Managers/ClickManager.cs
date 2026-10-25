using UnityEngine;
using UnityEngine.InputSystem;
public class ClickManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactibleLayer;
    [SerializeField] private InputActionReference pointAction;
    [SerializeField] private InputActionReference interactAction;


    private IInteractible interactibleChosen;
    private void OnEnable()
    {
        interactAction.action.Enable();
        pointAction.action.Enable();
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
        pointAction.action.Disable();
    }

    void Update()
    {
        if (!interactAction.action.WasPressedThisFrame())
            return;

        Vector2 screenPosition = pointAction.action.ReadValue<Vector2>();

        Vector2 worldPosition = cam.ScreenToWorldPoint(screenPosition);

        Collider2D hit = Physics2D.OverlapPoint(worldPosition, interactibleLayer);

        if (hit == null)
        {
            if (interactibleChosen != null)
            {
                interactibleChosen.OnDeselected();
            }
            return;
        }


        IInteractible interactible = hit.GetComponent<IInteractible>();

        if (interactible == null)
            return;

        if (interactibleChosen != null && interactibleChosen != interactible)
        {
            interactibleChosen.OnDeselected();
        }

        interactibleChosen = interactible;
        interactibleChosen.OnClicked();
    }
}
