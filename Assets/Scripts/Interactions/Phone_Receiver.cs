using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone_Receiver : MonoBehaviour, IInteractable, IEndDialogie
{
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] TaskManager _taskManager;
    [SerializeField] GoBackIntToChar _goBack;
    public bool _pickedUp = false;
    [SerializeField] Animator _phoneAnimator;

    [Header("Sounds")]
    public AudioSource AudioSource;
    [SerializeField] AudioClip _audioRinging;
    [SerializeField] AudioClip _audioPickUp;
    [SerializeField] AudioClip _audioPutDown;
    [SerializeField] Animator _phoneRecevierAnimator;
    //private Phone _phoneScript;

    [Header("Phone Sub Tasks")]
    //[SerializeField] List<AudioClip> voiceMailClip = new List<AudioClip>();//is this necessary?
    [SerializeField] List<DialogueSequence_SO> voiceMailDialogue = new List<DialogueSequence_SO>();
    public List<int> taskNumber = new List<int>();

    private void Start()
    {
        //_phoneScript = GameObject.Find("Phone_collider").GetComponent<Phone>();
        _taskManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();
        _dialogueSystem = GameObject.Find("DialogueManager").GetComponent<DialogueSystem>();
        _playerMovement = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        _goBack = GameObject.Find("GoBack").GetComponent<GoBackIntToChar>();

        //RingPhone();
    }

    private void Update()
    {
        //_receiver.GetComponent<Phone_Receiver>().AudioSource.isPlaying
        if (taskNumber.Count > 0 && AudioSource.clip != _audioRinging && _pickedUp == false)
        {
            _phoneAnimator.SetBool("FlashLight", true);
        }
        else
        {
            _phoneAnimator.SetBool("FlashLight", false);
        }

        if (taskNumber.Count == 0 && _pickedUp == true)
        {
            if (Mouse.current.rightButton.wasPressedThisFrame) // Right click pressed
            {
                _pickedUp = false;
                PutDown();
            }
        }
    }

    public void SetphoneTasks( DialogueSequence_SO voicemailDialogue, int taskValue) //AudioClip voiceClip,
    {
        //voiceMailClip.Add(voiceClip);
        voiceMailDialogue.Add(voicemailDialogue);
        taskNumber.Add(taskValue);
    }

    public void interact()
    {
        Debug.Log(transform.name);
        //an animation of phone receiver comes to your face
        //check if there is voice mail
        if (voiceMailDialogue.Count > 0)
        {
            this.GetComponent<Collider>().enabled = true;
            //_dayNightManager.taskCompleted(taskNumber[0]);
            _dialogueSystem.TriggerDialogueSequence(voiceMailDialogue[0], this.gameObject);//,voiceMailClip[0]
            //voiceMailClip.Remove(voiceMailClip[0]);
            //voiceMailDialogue.Remove(voiceMailDialogue[0]);
            //taskNumber.Remove(taskNumber[0]); 
             _playerMovement.enabled = false;
             _goBack.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            _playerMovement.enabled = true;
            _goBack.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
            //send an event to the DayNightManager to say task is completed

            // Testing Dialogue
            //_dialogueSystem.TriggerDialogueSequence(0, this.gameObject);
       
        

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
        _taskManager.taskCompleted(taskNumber[0]);
        voiceMailDialogue.Remove(voiceMailDialogue[0]);
        taskNumber.Remove(taskNumber[0]);
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
        _phoneRecevierAnimator.SetTrigger("PickedUp");
    }

    public void PutDown()
    {
        AudioSource.clip = _audioPutDown;
        AudioSource.Play();
        _phoneRecevierAnimator.SetTrigger("PutDown");
        _pickedUp = false;
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
