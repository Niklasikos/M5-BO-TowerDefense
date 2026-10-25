using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference zoomAction;
    [SerializeField] private InputActionReference dragAction;
    [SerializeField] private InputActionReference pointerDeltaAction;
    [SerializeField] private InputActionReference ControlAction;
    [SerializeField] private InputActionReference pinchFinger1;
    [SerializeField] private InputActionReference pinchFinger2;

    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private CinemachineConfiner2D confiner;
    [SerializeField] private Collider2D camBounds;

    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float zoomSpeed = 0.01f;
    [SerializeField] private float zoomMin = 3f;
    [SerializeField] private float zoomMax = 15f;
    [SerializeField] private float pinchZoomSpeed = 0.01f;

    private float previousPinchDistance;
    private bool wasPinching;

    private void OnEnable()
    {
        moveAction.action.Enable();
        zoomAction.action.Enable();
        dragAction.action.Enable();
        pointerDeltaAction.action.Enable();
        ControlAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        zoomAction.action.Disable();
        dragAction.action.Disable();
        pointerDeltaAction.action.Disable();
        ControlAction.action.Disable();
    }

    void Update()
    {
        MovementHandler();

        ZoomHandler();
        PinchZoomHandler();

        DragHandler();

        ClampPosition();
    }

    private void MovementHandler()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, input.y, 0);

        float zoom = cinemachineCamera.Lens.OrthographicSize;

        float zoomMultiplier = zoom / zoomMin;

        if (ControlAction.action.IsPressed())
        {
            moveSpeed = 15f;
        }
        else
        {
            moveSpeed = 10f;
        }

        transform.position += movement * moveSpeed * zoomMultiplier * Time.deltaTime;
    }

    private void ZoomHandler()
    {
        float scroll = zoomAction.action.ReadValue<float>();

        if (scroll == 0f)
            return;

        float zoom = cinemachineCamera.Lens.OrthographicSize;
        zoomSpeed = ControlAction.action.IsPressed() ? 1f : 0.5f;

        float newZoom = Mathf.Clamp(zoom - scroll * zoomSpeed, zoomMin, zoomMax);

        if (Mathf.Approximately(newZoom, zoom))
            return;

        cinemachineCamera.Lens.OrthographicSize = newZoom;
        confiner.InvalidateLensCache();
    }

    private void DragHandler()
    {
        if (!dragAction.action.IsPressed())
            return;

        Vector2 delta = pointerDeltaAction.action.ReadValue<Vector2>();

        float worldUnits = cinemachineCamera.Lens.OrthographicSize * 2f / Screen.height;

        transform.position += new Vector3(-delta.x, -delta.y, 0f) * worldUnits;
    }

    private void ClampPosition() // dit deel is door ai geschreven omdat mijn oude script niet werkte
    {
        Bounds bounds = camBounds.bounds;

        float halfHeight = cinemachineCamera.Lens.OrthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        Vector3 position = transform.position;

        float minX = bounds.min.x + halfWidth;
        float maxX = bounds.max.x - halfWidth;

        float minY = bounds.min.y + halfHeight;
        float maxY = bounds.max.y - halfHeight;

        position.x = minX <= maxX
            ? Mathf.Clamp(position.x, minX, maxX)
            : bounds.center.x;

        position.y = minY <= maxY
            ? Mathf.Clamp(position.y, minY, maxY)
            : bounds.center.y;

        transform.position = position;
    }

    private void PinchZoomHandler()
    {
        if (Touchscreen.current == null)
        {
            wasPinching = false;
            return;
        }

        var touches = Touchscreen.current.touches;

        if (!touches[0].press.isPressed || !touches[1].press.isPressed)
        {
            wasPinching = false;
            return;
        }

        Vector2 pos0 = touches[0].position.ReadValue();
        Vector2 pos1 = touches[1].position.ReadValue();

        float distance = Vector2.Distance(pos0, pos1);

        if (wasPinching)
        {
            float difference = distance - previousPinchDistance;

            float zoom = cinemachineCamera.Lens.OrthographicSize;

            float newZoom = Mathf.Clamp(
                zoom - difference * pinchZoomSpeed,
                zoomMin,
                zoomMax
            );

            if (!Mathf.Approximately(newZoom, zoom))
            {
                cinemachineCamera.Lens.OrthographicSize = newZoom;
                confiner.InvalidateLensCache();
            }
        }

        previousPinchDistance = distance;
        wasPinching = true;
    }
}
