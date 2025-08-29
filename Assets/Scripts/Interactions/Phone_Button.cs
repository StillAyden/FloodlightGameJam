using UnityEngine;
using UnityEngine.InputSystem;

public class Phone_Button : MonoBehaviour, IInteractable
{
    [Header("Sounds")]
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip _audioButtonPressed;
    [SerializeField] ButtonManager _buttonManager;

    //[SerializeField] ManagerSwitchInteractions _switchInteractions;
    //private Phone _phoneScript;

    private void Start()
    {
        _buttonManager = GameObject.Find("Buttons").GetComponent<ButtonManager>();
    }

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
        AudioSource.clip = _audioButtonPressed;
        AudioSource.Play();
        switch (transform.name)
        {
            case "Button_0":
                Debug.Log("Button_0 pressed!");
                _buttonManager.addNumber(0);
                break;
            case "Button_01":
                Debug.Log("Button_01 pressed!");
                _buttonManager.addNumber(1);
                break;
            case "Button_02":
                Debug.Log("Button_02 pressed!");
                _buttonManager.addNumber(2);
                break;
            case "Button_03":
                Debug.Log("Button_03 pressed!");
                _buttonManager.addNumber(3);
                break;
            case "Button_04":
                Debug.Log("Button_04 pressed!");
                _buttonManager.addNumber(4);
                break;
            case "Button_05":
                Debug.Log("Button_05 pressed!");
                _buttonManager.addNumber(5);
                break;
            case "Button_06":
                Debug.Log("Button_06 pressed!");
                _buttonManager.addNumber(6);
                break;
            case "Button_07":
                Debug.Log("Button_07 pressed!");
                _buttonManager.addNumber(7);
                break;
            case "Button_08":
                Debug.Log("Button_08 pressed!");
                _buttonManager.addNumber(8);
                break;
            case "Button_09":
                Debug.Log("Button_09 pressed!");
                _buttonManager.addNumber(9);
                break;
            case "Button_Asterisk":
                Debug.Log("Button_Asterisk pressed!");
                _buttonManager.addNumber(01);
                break;
            case "Button_Hash":
                Debug.Log("Button_Hash pressed!");
                _buttonManager.addNumber(02);
                break;
            case "Button_PassCall":
                Debug.Log("Button_PassCall pressed!");
                _buttonManager.addNumber(03);
                break;
        }
    }
}
