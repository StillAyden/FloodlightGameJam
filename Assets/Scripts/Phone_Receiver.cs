using UnityEngine;
using UnityEngine.InputSystem;

public class Phone_Receiver : MonoBehaviour, IInteractable
{
    //private Phone _phoneScript;

    //private void Start()
    //{
    //    _phoneScript = GameObject.Find("Phone_collider").GetComponent<Phone>();
    //}
    public void interact()
    {
        Debug.Log(transform.name);
    }

    //private void Update()
    //{
    //    if (Mouse.current.rightButton.wasPressedThisFrame) // Right click pressed
    //    {
    //        _phoneScript.enabled = true;
    //        //put down phone
    //    }
    //}

}
