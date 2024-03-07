using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float zoomSpeed = 5f;
    public float maxZoom = 10f;
    public float minZoom = 2f;

    private Camera mainCamera;
    private Vector3 lastMousePosition;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleMouseMovement();
        HandleMouseZoom();
        HandleTouchMovement();
        HandleTouchZoom();
    }

    private void HandleMouseMovement()
    {
        if (Input.GetMouseButtonDown(0)) // Начало перемещения при нажатии кнопки мыши
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) // Перемещение при зажатой кнопке мыши
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.Translate(-delta * moveSpeed * Time.deltaTime);
            lastMousePosition = Input.mousePosition;
        }
    }

    private void HandleMouseZoom()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        float newSize = mainCamera.orthographicSize - zoomInput * zoomSpeed;
        mainCamera.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
    }

    private void HandleTouchMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchDeltaPosition = touch.deltaPosition;

            Vector3 moveDirection = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 0f).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void HandleTouchZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            float newSize = mainCamera.orthographicSize + deltaMagnitudeDiff * zoomSpeed * Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        }
    }
}
