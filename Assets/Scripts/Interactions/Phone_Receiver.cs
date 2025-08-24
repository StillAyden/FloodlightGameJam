using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone_Receiver : MonoBehaviour, IInteractable, IEndDialogie
{
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] DayNightManager _dayNightManager;
    [SerializeField] GoBackIntToChar _goBack;
    [SerializeField] bool _pickedUp = false;

    [Header("Sounds")]
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip _audioRinging;
    [SerializeField] AudioClip _audioPickUp;
    [SerializeField] AudioClip _audioPutDown;
    //private Phone _phoneScript;

    [Header("Phone Sub Tasks")]
    [SerializeField] List<AudioClip> voiceMailClip = new List<AudioClip>();
    [SerializeField] List<DialogueSequence_SO> voiceMailDialogue = new List<DialogueSequence_SO>();
    [SerializeField] List<int> taskNumber = new List<int>();

    private void Start()
    {
        //_phoneScript = GameObject.Find("Phone_collider").GetComponent<Phone>();
        _dayNightManager = GameObject.Find("Day/Night Manager").GetComponent<DayNightManager>();
        _dialogueSystem = GameObject.Find("DialogueManager").GetComponent<DialogueSystem>();
        _playerMovement = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        _goBack = GameObject.Find("GoBack").GetComponent<GoBackIntToChar>();

        //RingPhone();
    }

    public void SetphoneTasks(AudioClip voiceClip, DialogueSequence_SO voicemailDialogue, int taskValue)
    {
        voiceMailClip.Add(voiceClip);
        voiceMailDialogue.Add(voicemailDialogue);
        taskNumber.Add(taskValue);
    }

    public void interact()
    {
        Debug.Log(transform.name);
        //an animation of phone receiver comes to your face
        //check if there is voice mail
        if (voiceMailClip.Count > 0)
        {
            _dayNightManager.taskCompleted(taskNumber[0]);
            _dialogueSystem.TriggerDialogueSequence(voiceMailDialogue[0], voiceMailClip[0], this.gameObject);
            voiceMailClip.Remove(voiceMailClip[0]);
            voiceMailDialogue.Remove(voiceMailDialogue[0]);
            taskNumber.Remove(taskNumber[0]); 
        }
        //send an event to the DayNightManager to say task is completed

        // Testing Dialogue
        //_dialogueSystem.TriggerDialogueSequence(0, this.gameObject);
        _playerMovement.enabled = false;
        _goBack.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        //temp testing
        if (_pickedUp == false)
        {
            PickedUp();
            _pickedUp = true;
            
        }


        //Have the phone receiver to start the dialogue

        //once dialogue is completed phone is put down/or you can hold it up
    }

    public void endDialogue()
    {
        _playerMovement.enabled = true;
        _goBack.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PutDown();
        _pickedUp = false;
    }

    public void RingPhone() //maybe something can trigger the ringing from something
    {
        AudioSource.clip = _audioRinging;
        AudioSource.Play();
    }

    public void PickedUp()
    {
        AudioSource.clip = _audioPickUp;
        AudioSource.Play();
    }

    public void PutDown()
    {
        AudioSource.clip = _audioPickUp;
        AudioSource.Play();
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
