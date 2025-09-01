using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour, IInteractable
{
    [Header("Other Things")]
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] GoBackIntToChar _goBack;
    [SerializeField] TaskManager _taskManager;
    [Header("Screen UI")]
    [SerializeField] ComputerManager _screen;
    [Header("Sounds")]
    [SerializeField] AudioSource _audioSourceComputer;
    [SerializeField] AudioSource _audioSourceMail;
    [SerializeField] AudioClip _audioIdling;
    [SerializeField] AudioClip _audioReceiveMail;


    [Header("Email Sub Tasks")]
    //[SerializeField] List<AudioClip> voiceMailClip = new List<AudioClip>();//is this necessary?
    public List<string> HeaderTitle = new List<string>();
    public List<string> bodyText = new List<string>();
    [SerializeField] List<int> taskNumber = new List<int>();
    public void Start()
    {
        _audioSourceComputer.clip = _audioIdling;
        _audioSourceComputer.Play();
        _playerMovement = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        _goBack = GameObject.Find("GoBack").GetComponent<GoBackIntToChar>();
        _screen = GameObject.Find("canvComputerScreen").GetComponent<ComputerManager>();
        _taskManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();
        //ReceiveMail();
    }
    public void interact()
    {
        Debug.Log(transform.name);
        //_playerMovement.enabled = false;
        //_goBack.enabled = false;
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;

        //Have the player click on the screen to access the menus


        // send an event to the DayNight Manager to say task is completed
        _taskManager.taskCompleted(taskNumber[0]);
        HeaderTitle.Remove(HeaderTitle[0]);
        bodyText.Remove(bodyText[0]);
        taskNumber.Remove(taskNumber[0]);
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
