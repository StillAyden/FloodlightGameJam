using UnityEngine;
using UnityEngine.InputSystem; // Needed for new Input System
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Input Manager")]
    [Header("Movement")]
    [SerializeField] Transform _cameraFPS;
    [SerializeField, Range(0, 15f)] float _mouseSensitivity;
    [SerializeField, Range(0, 0.1f)] float _mouseLerpSpeed;
    [SerializeField, Range(0, -90f)] float _clampUp;
    [SerializeField, Range(0f, 90f)] float _clampDown;
    [SerializeField, Range(0f, -90f)] float _clampLeft;
    [SerializeField, Range(0f, 90f)] float _clampRight;
    float _rotationX = 0f;
    float _rotationY = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        getMouseMovement();
        useRacast();
    }

    public void getMouseMovement()
    {

        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue() * _mouseSensitivity * Time.deltaTime;

            _rotationX -= mouseDelta.y;
            _rotationX = Mathf.Clamp(_rotationX, _clampUp, _clampDown);
            _rotationY += mouseDelta.x;
            _rotationY = Mathf.Clamp(_rotationY, _clampLeft, _clampRight);

            Quaternion targetRotation = Quaternion.Euler(_rotationX, _rotationY, 0f);
            //lerp
            _cameraFPS.localRotation = Quaternion.Slerp(_cameraFPS.localRotation, targetRotation, _mouseLerpSpeed);
        }
    }

    public void useRacast()
    {
        //use Raycast to hit an interactable gameObject
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
        // Get current mouse position
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Create ray from camera to that position
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        // Declare a RaycastHit variable to store hit information
        RaycastHit hit;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E key pressed!");

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // If the raycast hits something, 'hit' now contains the collision data
                Debug.Log("Hit " + hit.collider.name + " at point " + hit.point);

                // You can then access various properties of the hit object
                // Example: Change the color of the hit object
                hit.collider.GetComponent<IInteractable>()?.interact();
            }
        }

    }
}
