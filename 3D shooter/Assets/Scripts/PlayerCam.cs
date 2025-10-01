using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Header("References")]
    public Transform playerBody;
    public Transform cameraTransform; 

    [Header("Settings")]
    public float mouseSensitivity = 100f;
    public float clampAngle = 85f; 

    private float xRotation = 0f; 

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    private void Update()
    {
        Vector2 mouseDelta = onFoot.Look.ReadValue<Vector2>();

        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        // Rotate player body 
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate camera 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
