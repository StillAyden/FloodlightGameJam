using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour, IEndDialogie
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool _pressSpecificButton;
    public int _pressSpecificButtonIndex = -1;

    public string currentPhoneNumber;
    [SerializeField] GameObject _dialogueStuff;

    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] GoBackIntToChar _goBack;

    [SerializeField] Phone_Receiver _phoneReceiverPickedUp;

    [Header("Get Tasks")]
    [SerializeField] TaskManager _taskManager;
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] List<string> _setNumber = new List<string>();
    [SerializeField] List<DialogueSequence_SO> _setDialogue = new List<DialogueSequence_SO>();
    public List<int> taskNumber = new List<int>();
    void Start()
    {
        _taskManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();
        _phoneReceiverPickedUp = GameObject.Find("Receiver").GetComponent<Phone_Receiver>();
        _dialogueSystem = GameObject.Find("DialogueManager").GetComponent<DialogueSystem>();
        _playerMovement = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        _goBack = GameObject.Find("GoBack").GetComponent<GoBackIntToChar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNumber(int numberPressed)
    {
        if (!_pressSpecificButton && _phoneReceiverPickedUp._pickedUp == true)
        {
           
            if (_setNumber != null && _setNumber.Count > 0 && _setNumber[0] != null)
            {
                currentPhoneNumber = currentPhoneNumber + numberPressed;
                if (currentPhoneNumber == _setNumber[0])
                {
                    //if it cotains # set it to null

                    if (currentPhoneNumber == _setNumber[0])
                    {
                        _dialogueSystem.TriggerDialogueSequence(_setDialogue[0], this.gameObject);//,voiceMailClip[0]
                        _playerMovement.enabled = false;
                        _goBack.enabled = false;
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                        //gat canvas and start Dialogie Manager
                    }
                }

                if (currentPhoneNumber.Length > 10 && currentPhoneNumber != _setNumber[0])
                {
                    clearNumber();
                }
            }
            

        }
        else
        {
            if (numberPressed == _pressSpecificButtonIndex)
            {
                _pressSpecificButton = false;
                _pressSpecificButtonIndex = -1;
                //_dialogueStuff.SetActive(true);
                _dialogueStuff.GetComponent<CanvasGroup>().alpha = 1;
                _dialogueStuff.GetComponent<CanvasGroup>().interactable = true;
                _dialogueStuff.GetComponent<CanvasGroup>().blocksRaycasts = true;
                _playerMovement.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
    }


    public void clearNumber()
    {
        currentPhoneNumber = null;
    }
    public void endDialogue()
    {
        _phoneReceiverPickedUp.PutDown();
        _playerMovement.enabled = true;
        _goBack.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _taskManager.taskCompleted(taskNumber[0]);
        _setDialogue.Remove(_setDialogue[0]);
        _setNumber.Remove(_setNumber[0]);
        taskNumber.Remove(taskNumber[0]);
    }


    public void SetDialTasks(string number, DialogueSequence_SO dialogues, int taskValue)
    {
        _setNumber.Add(number);
        _setDialogue.Add(dialogues);
        taskNumber.Add(taskValue);
    }
}
