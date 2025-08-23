using UnityEngine;

public class CameraZooming : MonoBehaviour
{

    [SerializeField] Camera cam;

    [SerializeField] float zoomSpeed = 5f; // Default Zoom Speed
    [SerializeField] float minZoom = 2f;
    [SerializeField] float maxZoom = 15f;

    [SerializeField] float zoomSmooth = 0.2f; // Defined Time for Smoothing

    private float targetZoom;
    private float zoomVelocity;
    private Vector3 zoomCenter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        ZoomInput();
        ApplyZoom();
    }

    private void ZoomInput()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            zoomCenter = cam.ScreenToWorldPoint(Input.mousePosition);

            targetZoom -= scrollInput * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }
    }

    private void ApplyZoom()
    {
        float previousZoom = cam.orthographicSize;

        cam.orthographicSize = Mathf.SmoothDamp(
            cam.orthographicSize,
            targetZoom,
            ref zoomVelocity,
            zoomSmooth
        );

        if (previousZoom != cam.orthographicSize)
        {
            ZoomTowardsMouse(zoomCenter, previousZoom);
        }
    }

    private void ZoomTowardsMouse(Vector3 point, float previousValue)
    {
        float zoomDif = previousValue - cam.orthographicSize;
        Vector3 direction = (point - transform.position).normalized;

        float distance = Vector3.Distance(transform.position, point);

        transform.position += direction * distance * (zoomDif / previousValue);
    }
}
