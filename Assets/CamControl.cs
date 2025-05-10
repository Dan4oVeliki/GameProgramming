using UnityEngine;

public class CamControl : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform cameraTransform;    // Reference to the camera
    public Transform pivotObject;         // Object that will pitch (up/down)
    public float cameraDistance = 5.0f;  // Distance from the tower
    public float mouseSensitivity = 5.0f;
    public float pitchMin = -30f;
    public float pitchMax = 60f;

    private float yaw = 0f;
    private float pitch = 0f;
    private bool isDead = false;

    private void Start()
    {

        Vector3 angles = cameraTransform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleCamera();
    }

    private void HandleCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        // Rotate ONLY the Tower on Y axis
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Rotate PivotObject up/down (pitch)
        pivotObject.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Position and rotate the camera
        Vector3 direction = new Vector3(0, 0, -cameraDistance);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        cameraTransform.position = transform.position + rotation * direction;
        cameraTransform.LookAt(transform);
    }


}
