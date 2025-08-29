using UnityEngine;
using UnityEngine.InputSystem;

public class GoBackIntToChar : MonoBehaviour
{
    [SerializeField] ManagerSwitchInteractions _switchInteractions;

    
    void Start()
    {
        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame) // Right click pressed
        {
            Transform grandParent = transform.parent.parent;

            if (grandParent.name != "Character")
            {
                exitInteraction();
            }

        }
    }

    public void exitInteraction()
    {
        IInteractable interactable = transform.parent.parent.GetComponent<IInteractable>();
        if (interactable != null)
        {
            MonoBehaviour script = interactable as MonoBehaviour;
            script.enabled = true; // enable whichever script it is
            Debug.Log(interactable.GetType().Name + " script re-enabled on " + transform.parent.parent.name);
        }

        _switchInteractions.InteractionToCharacter();
        Debug.Log("BackToChar");
    }
}
