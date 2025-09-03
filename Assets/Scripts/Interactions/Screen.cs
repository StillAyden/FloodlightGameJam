using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Screen : MonoBehaviour, IInteractable
{
    [Header("Other Things")]
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] GoBackIntToChar _goBack;
    [SerializeField] TaskManager _taskManager;
    [SerializeField] Computer _computer;
    [Header("Screen UI")]
    [SerializeField] ComputerManager _screen;
    [Header("Sounds")]
  
    [SerializeField] AudioSource _audioSourceMail;

    [SerializeField] AudioClip _audioReceiveMail;


    [Header("Email Sub Tasks")]
    //[SerializeField] List<AudioClip> voiceMailClip = new List<AudioClip>();//is this necessary?
    public List<string> HeaderTitle = new List<string>();
    public List<string> bodyText = new List<string>();
    [SerializeField] List<int> taskNumber = new List<int>();
    public void Start()
    {

        _playerMovement = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        _goBack = GameObject.Find("GoBack").GetComponent<GoBackIntToChar>();
        _screen = GameObject.Find("canvComputerScreen").GetComponent<ComputerManager>();
        _taskManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();
        _computer = GameObject.Find("Computer_collider").GetComponent<Computer>();
        //ReceiveMail();
    }

    private void Update()
    {
        if (taskNumber.Count == 0 )
        {
            if (Mouse.current.rightButton.wasPressedThisFrame) // Right click pressed
            {
                this.GetComponent<Collider>().enabled = false;
                _computer.GetComponent<Collider>().enabled = true;
                _computer._interacted = false;
            }
        }
    }
    public void interact()
    {
        Debug.Log(transform.name);
        //_playerMovement.enabled = false;
        //_goBack.enabled = false;
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
        this.GetComponent<Collider>().enabled = false;
        //Have the player click on the screen to access the menus
        _computer.GetComponent<Collider>().enabled = true;
        
        // send an event to the DayNight Manager to say task is completed
        _taskManager.taskCompleted(taskNumber[0]);
        HeaderTitle.Remove(HeaderTitle[0]);
        bodyText.Remove(bodyText[0]);
        taskNumber.Remove(taskNumber[0]);
        //_computer._interacted = false;
        //_screen.TurnComputerOn();

    }

    public void SetemailTasks(string Header, string BodyText, int taskValue)
    {
        HeaderTitle.Add(Header);
        bodyText.Add(BodyText);
        taskNumber.Add(taskValue);
    }

    public void ReceiveMail() //maybe something can trigger the receiving mails from something
    {
        _audioSourceMail.clip = _audioReceiveMail;
        _audioSourceMail.Play();
    }
}
