using UnityEngine;
using UnityEngine.InputSystem;


public class CameraC : MonoBehaviour
{
    [SerializeField] public float mouseSensibilityX = 100.0f;
    [SerializeField] public float mouseSensibilityY = 100.0f;
    [SerializeField] public float maxRotationX = 80.0f;
    [SerializeField] public float maxRotationY = 80.0f;

    private float rotationX;
    private float rotationY;

    
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
    }

    public void OnLookX(InputAction.CallbackContext context)
    {
        float deltaX = context.ReadValue<float>() * mouseSensibilityX * Time.deltaTime;
        rotationY += deltaX;
        rotationY = Mathf.Clamp(rotationY, -maxRotationY, maxRotationY);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    public void OnLookY(InputAction.CallbackContext context)
    {
        float deltaY = context.ReadValue<float>() * mouseSensibilityY * Time.deltaTime;
        rotationX -= deltaY;
        rotationX = Mathf.Clamp(rotationX, -maxRotationX, maxRotationX);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
