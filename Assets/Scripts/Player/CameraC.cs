using Unity.Mathematics;
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
       Cursor.lockState = CursorLockMode.Confined; 
       Camera.main.transform.rotation = new Quaternion (0,0,0,0);
    }

    public void OnLookX(InputAction.CallbackContext value)
    {
        float deltaX = value.ReadValue<float>() * mouseSensibilityX * Time.deltaTime;
        rotationY += deltaX;
        rotationY = Mathf.Clamp(rotationY, -maxRotationY, maxRotationY);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    public void OnLookY(InputAction.CallbackContext value)
    {
        float deltaY = value.ReadValue<float>() * mouseSensibilityY * Time.deltaTime;
        rotationX -= deltaY;
        rotationX = Mathf.Clamp(rotationX, -maxRotationX, 10);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
