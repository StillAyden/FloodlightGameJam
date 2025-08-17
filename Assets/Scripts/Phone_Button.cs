using UnityEngine;
using UnityEngine.InputSystem;

public class Phone_Button : MonoBehaviour, IInteractable
{

    [SerializeField] ManagerSwitchInteractions _switchInteractions;
    //private Phone _phoneScript;

    //private void Start()
    //{
    //    _phoneScript = GameObject.Find("Phone_collider").GetComponent<Phone>();
    //}

    //private void Update()
    //{
    //    if (Mouse.current.rightButton.wasPressedThisFrame) // Right click pressed
    //    {
    //        _phoneScript.enabled = true;
    //    }
    //}
    public void interact()
    {
        // Use the GameObject's name to determine which button was pressed
        switch (transform.name)
        {
            case "Button_0":
                Debug.Log("Button_0 pressed!");
 
                break;
            case "Button_01":
                Debug.Log("Button_01 pressed!");
    
                break;
            case "Button_02":
                Debug.Log("Button_02 pressed!");
          
                break;
            case "Button_03":
                Debug.Log("Button_03 pressed!");
     
                break;
            case "Button_04":
                Debug.Log("Button_04 pressed!");
             
                break;
            case "Button_05":
                Debug.Log("Button_05 pressed!");
           
                break;
            case "Button_06":
                Debug.Log("Button_06 pressed!");

                break;
            case "Button_07":
                Debug.Log("Button_07 pressed!");

                break;
            case "Button_08":
                Debug.Log("Button_08 pressed!");

                break;
            case "Button_09":
                Debug.Log("Button_09 pressed!");

                break;
            case "Button_Asterisk":
                Debug.Log("Button_Asterisk pressed!");
                break;
            case "Button_Hash":
                Debug.Log("Button_Hash pressed!");
                break;
            case "Button_PassCall":
                Debug.Log("Button_PassCall pressed!");
                break;
        }
    }
}
