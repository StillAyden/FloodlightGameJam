using UnityEngine;
using UnityEngine.InputSystem;

public class ColliderReplacingRayCast : MonoBehaviour
{
    [SerializeField] Collider currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(">>> ENTER " + other.name + " | Tag: " + other.tag + " | Layer: " + LayerMask.LayerToName(other.gameObject.layer));
    
        if (other.CompareTag("Interactable"))
        {
            Debug.Log("Player entered trigger: " + other.name);
            currentInteractable = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("<<< EXIT " + other.name + " | Tag: " + other.tag + " | Layer: " + LayerMask.LayerToName(other.gameObject.layer));
        if (other.CompareTag("Interactable") && other == currentInteractable)
        {
            Debug.Log("Player left trigger: " + other.name);
            currentInteractable = null;
        }
    }

    private void Update()
    {
        if (currentInteractable != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E key pressed on: " + currentInteractable.name);
            currentInteractable.GetComponent<IInteractable>()?.interact();
        }
    }
}
