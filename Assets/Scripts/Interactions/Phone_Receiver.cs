using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone_Receiver : MonoBehaviour, IInteractable, IEndDialogie
{
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] GoBackIntToChar _goBack;
    //private Phone _phoneScript;

    private void Start()
    {
        //_phoneScript = GameObject.Find("Phone_collider").GetComponent<Phone>();
        _dialogueSystem = GameObject.Find("DialogueManager").GetComponent<DialogueSystem>();
        _playerMovement = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        _goBack = GameObject.Find("GoBack").GetComponent<GoBackIntToChar>();
    }
    public void interact()
    {
        Debug.Log(transform.name);
        //an animation of phone receiver comes to your face

        // Testing Dialogue
        _dialogueSystem.TriggerDialogueSequence(0,this.gameObject);
        _playerMovement.enabled = false;
        _goBack.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        //Have the phone receiver to start the dialogue

        //once dialogue is completed phone is put down/or you can hold it up
    }

    public void endDialogue()
    {
        _playerMovement.enabled = true;
        _goBack.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
