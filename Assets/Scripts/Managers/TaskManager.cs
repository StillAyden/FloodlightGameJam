using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TaskManager: MonoBehaviour
{
    [SerializeField] TaskSet[] _actsOrChapters;
    [SerializeField] int getNumberOfDays;
    [SerializeField] int currentDay;
    [SerializeField] bool tasksCompleted = false;
    [SerializeField] int getNumberOfTasks;

    [SerializeField] GoBackIntToChar _gobacktoChar;
    [SerializeField] Animator _fadeInOut;

    [Header("Send Tasks")]
    [SerializeField] private Phone_Receiver phoneManager;
    [SerializeField] private SignHere documentManager;

    [Header("Sus Task/s")]
    [SerializeField] List<int> _susTasksValue = new List<int>();

    [Header("Unlock through Progress")]
    [SerializeField] Computer _unlockComputer;
    [SerializeField] Phone _unlockPhone;
    [SerializeField] Document _unlockDocument;
    //get reference canInteract on whatever interactive scripts
    //turn to true once a specifc task is activated



    void Start()
    {
        phoneManager = GameObject.Find("Receiver").GetComponent<Phone_Receiver>();
        documentManager = GameObject.Find("SignHere").GetComponent<SignHere>();

        getNumberOfDays = _actsOrChapters.Length;
        currentDay = 0;
        getNumberOfTasks = _actsOrChapters[currentDay].numberOfTasks;
        //taskCompleted();
      
        _unlockPhone.enabled = true;
        getTasks();
    }

    private void Update()
    {
        //checkSubPhoneTasks();
        //checkSubDocumentTasks();
        CheckAllSubTasks();
    }
    public void getTasks()
    {
        for (int i = 0; i < getNumberOfTasks; i++)
        {
            var task = _actsOrChapters[currentDay].tasks[i];
            //Debug.Log("Task has added: "+ task.interactionType);
            task.completed = false;
            _actsOrChapters[currentDay].tasks[i] = task;
            // switch based on InteractionType
            switch (task.interactionType)
            {
                case InteractionType.Document:
                    Debug.Log("Add Document: " + task.headerOrTitle);
                    // TODO: add more documents to the Document system
                    if (task.taskType == TaskType.Sub)
                    {
                        //phoneManager.SetphoneTasks(task.subDialogues, i);//task.clip,
                        documentManager.SetdocumentTasks(task.headerOrTitle, task.text, i);
                    }
                    else
                    {
                        Debug.Log("It is a Sus task");
                        _susTasksValue.Add(i);
                    } 
                    //testing
                    Debug.Log("Task Number: " + i + " Header: " + task.headerOrTitle + " Body: " + task.text);

                    //send the current i to relevant script this will help for completing tasks

                    break;

                case InteractionType.ReadEmail:
                    Debug.Log("Add Email: " + task.headerOrTitle);
                    // TODO: add emails to your system
                    if (task.taskType == TaskType.Sub)
                    {
                        //phoneManager.SetphoneTasks(task.subDialogues, i);//task.clip,
                    }
                    else
                    {
                        Debug.Log("It is a Sus task");
                        _susTasksValue.Add(i);
                    }
                    //testing
                    Debug.Log("Task Number: " + i + " Header: " + task.headerOrTitle + " Body: " + task.text);

                    //send the current i to relevant script this will help for completing tasks
                    break;

                case InteractionType.RingPhone:
                    //Debug.Log("Make Phone Ring, Dialog: " + task.subDialogues);
                    // TODO: add the clip, dialogue and taskValue to make a voice mail
                    if (task.taskType == TaskType.Sub)
                    {
                        phoneManager.SetphoneTasks(task.subDialogues, i);//task.clip,
                    }
                    else
                    {
                        Debug.Log("It is a Sus task");
                        _susTasksValue.Add(i);
                    }

                    //testing
                    Debug.Log("Task Number: " + i + " Dialogue: " + task.subDialogues.name);

                    //send the current i to relevant script this will help for completing tasks
                    break;
            }/////////
        }
    }

    //might change the logic after the game jam is completed to make this better
    public void taskCompleted(int whichTaskCompleted)
    {
        tasksCompleted = true;
        TaskData task = _actsOrChapters[currentDay].tasks[whichTaskCompleted];
        task.completed = true;
        _actsOrChapters[currentDay].tasks[whichTaskCompleted] = task;

        Debug.Log("Is this task completed: " + task.completed);
        //send the task to the relevant interactions that causes it, such as add an email, add a document, add a voicemail
        for (int i = 0; i < _actsOrChapters[currentDay].tasks.Count; i++)
        {
            if (!_actsOrChapters[currentDay].tasks[i].completed) // if any task is not completed
            {
                tasksCompleted = false;
                break; // no need to check further
            }
        }

        if (susTaskInProgress == true)
        {
            susTaskInProgress = false;
            susTaskIndex++;
        }

        if (tasksCompleted == true)
        {
            // change new day
            nextDay();
        }
    }

    public void checkToUnlock()
    {
        //switch on certain interactions
        switch (currentDay)
        {
            case 0:
                //check until this task is completed to unlock
                //enable phone

                break;
            case 1:
                //check until this task is completed to unlock
                _unlockDocument.enabled = true;
                break;
            case 2:
                //check until this task is completed to unlock
                //after the button dial_01 to call technician 
                //computer unlocks
                if (_actsOrChapters[2].tasks[0].completed == true)//Based on Narrative Script
                {
                    _unlockComputer.enabled = true;
                }
                
                //sends an email
                break;
            case 3:
                //check until this task is completed to unlock
                break;
        }
    }


    private int susTaskIndex = 0;
    private bool susTaskInProgress = false;

    public void CheckAllSubTasks()
    {
        // 1. Check if ALL subtasks are completed (regardless of type)
        bool allSubsCompleted = true;

        for (int i = 0; i < _actsOrChapters[currentDay].tasks.Count; i++)
        {
            var task = _actsOrChapters[currentDay].tasks[i];

            if (task.taskType == TaskType.Sub) // only care about subtasks
            {
                if (!task.completed) // if ANY subtask is not done
                {
                    allSubsCompleted = false;
                    break;
                }
            }
        }

        Debug.Log("All Subtasks completed? " + allSubsCompleted);

        // 2. If all subtasks are done, trigger first Sus task
        if (allSubsCompleted && !susTaskInProgress)
        {
            if (susTaskIndex >= _susTasksValue.Count)
                return; // no more sus tasks available

            int taskIndex = _susTasksValue[susTaskIndex];
            var susTask = _actsOrChapters[currentDay].tasks[taskIndex];

            if (!susTask.completed)
            {
                Debug.Log("Starting Sus Task: " + taskIndex);

                switch (susTask.interactionType)
                {
                    case InteractionType.RingPhone:
                        // Optional safeguard: don’t ring if already picked up
                        if (!phoneManager._pickedUp)
                        {
                            phoneManager.SetphoneTasks(susTask.subDialogues, taskIndex);
                            phoneManager.RingPhone();
                        }
                        break;

                    case InteractionType.Document:
                        documentManager.SetdocumentTasks(susTask.headerOrTitle, susTask.text, taskIndex);
                        break;

                        // add more cases here if you have more interaction types
                }

                susTaskInProgress = true;
            }
        }
    }

    //public void checkSubPhoneTasks()
    //{
    //    //check if Sub Phone task are completed.
    //    bool _allPhoneSubCompleted = true;

    //    for (int i = 0; i < _actsOrChapters[currentDay].tasks.Count; i++)
    //    {
    //        var task =_actsOrChapters[currentDay].tasks[i];
    //        if (task.interactionType == InteractionType.RingPhone && task.taskType == TaskType.Sub)
    //        {
    //            // If the task is not completed or phone has been picked up, mark as not completed
    //            if (!task.completed || phoneManager._pickedUp == true)
    //            {
    //                _allPhoneSubCompleted = false;
    //                break; // no need to check further
    //            }
    //        }

    //    }
    //    Debug.Log("Subtasks Phone completed? " + _allPhoneSubCompleted + " | Phone picked up? " + phoneManager._pickedUp);

    //    ////this checks the sus tasks for the phone
    //    int currentSusTask = -1;
    //    if (_allPhoneSubCompleted && !phoneManager._pickedUp)
    //    {
    //        // Stop if out of range
    //        if (susTaskIndex >= _susTasksValue.Count)
    //            return;

    //        int taskIndex = _susTasksValue[susTaskIndex];
    //        var task = _actsOrChapters[currentDay].tasks[taskIndex];

    //        if (!task.completed && !susTaskInProgress)
    //        {
    //            currentSusTask = taskIndex;
    //            Debug.Log("Start this Sus Task: " + taskIndex);

    //            phoneManager.SetphoneTasks(task.subDialogues, taskIndex);
    //            phoneManager.RingPhone();
    //            susTaskInProgress = true;
    //            // move to next entry for the next time
    //            //susTaskIndex++;
    //        }


    //    }

    //    //if (susTaskInProgress)
    //    //    return; // don’t start a new Sus task while one is in progress

    //    //// Loop through your sus task indices
    //    //for (int i = susTaskIndex; i < _susTasksValue.Count; i++)
    //    //{
    //    //    int taskIndex = _susTasksValue[i];
    //    //    var task = _actsOrChapters[currentDay].tasks[taskIndex];

    //    //    if (!task.completed)
    //    //    {
    //    //        // Handle by type
    //    //        if (task.interactionType == InteractionType.RingPhone)
    //    //        {
    //    //            // Skip if phone already picked up
    //    //            if (phoneManager._pickedUp)
    //    //                return;

    //    //            Debug.Log("Starting Phone Sus Task: " + taskIndex);
    //    //            phoneManager.SetphoneTasks(task.subDialogues, taskIndex);
    //    //            phoneManager.RingPhone();
    //    //        }
    //    //        else if (task.interactionType == InteractionType.Document)
    //    //        {
    //    //            Debug.Log("Starting Document Sus Task: " + taskIndex);
    //    //            documentManager.SetdocumentTasks(task.headerOrTitle, task.text, taskIndex);
    //    //        }

    //    //        susTaskInProgress = true;
    //    //        // susTaskIndex is incremented only after taskCompleted()
    //    //        return;
    //    //    }
    //    //}
    //}

    //public void checkSubDocumentTasks()
    //{
    //    //check if Sub Phone task are completed.
    //    bool _allDocumentSubCompleted = true;

    //    for (int i = 0; i < _actsOrChapters[currentDay].tasks.Count; i++)
    //    {
    //        var task = _actsOrChapters[currentDay].tasks[i];
    //        if (task.interactionType == InteractionType.Document && task.taskType == TaskType.Sub)
    //        {
    //            // If the task is not completed, mark as not completed
    //            if (!task.completed)
    //            {
    //                _allDocumentSubCompleted = false;
    //                break; // no need to check further
    //            }
    //        }

    //    }
    //    Debug.Log("Subtasks Document completed? " + _allDocumentSubCompleted);

    //    ////this checks the sus tasks for the phone
    //    int currentSusTask = -1;
    //    if (_allDocumentSubCompleted)
    //    {
    //        // Stop if out of range
    //        if (susTaskIndex >= _susTasksValue.Count)
    //            return;

    //        int taskIndex = _susTasksValue[susTaskIndex];
    //        var task = _actsOrChapters[currentDay].tasks[taskIndex];

    //        if (!task.completed && !susTaskInProgress)
    //        {
    //            currentSusTask = taskIndex;
    //            Debug.Log("Start this Sus Task: " + taskIndex);

    //            documentManager.SetdocumentTasks(task.headerOrTitle, task.text, taskIndex);
    //            susTaskInProgress = true;
    //            // move to next entry for the next time
    //            //susTaskIndex++;
    //        }


    //    }

    //    //if (susTaskInProgress)
    //    //    return; // don’t start a new Sus task while one is in progress

    //    //// Loop through your sus task indices
    //    //for (int i = susTaskIndex; i < _susTasksValue.Count; i++)
    //    //{
    //    //    int taskIndex = _susTasksValue[i];
    //    //    var task = _actsOrChapters[currentDay].tasks[taskIndex];

    //    //    if (!task.completed)
    //    //    {
    //    //        // Handle by type
    //    //        if (task.interactionType == InteractionType.RingPhone)
    //    //        {
    //    //            // Skip if phone already picked up
    //    //            if (phoneManager._pickedUp)
    //    //                return;

    //    //            Debug.Log("Starting Phone Sus Task: " + taskIndex);
    //    //            phoneManager.SetphoneTasks(task.subDialogues, taskIndex);
    //    //            phoneManager.RingPhone();
    //    //        }
    //    //        else if (task.interactionType == InteractionType.Document)
    //    //        {
    //    //            Debug.Log("Starting Document Sus Task: " + taskIndex);
    //    //            documentManager.SetdocumentTasks(task.headerOrTitle, task.text, taskIndex);
    //    //        }

    //    //        susTaskInProgress = true;
    //    //        // susTaskIndex is incremented only after taskCompleted()
    //    //        return;
    //    //    }
    //    //}
    //}

    public void nextDay()
    {
        currentDay++;
        if (currentDay == getNumberOfDays)
        {
            Debug.Log("Finished Game");
        }
        else
        {
            //maybe a dialogue that appears on the screen to say end of the day perhaps?
            _fadeInOut.SetTrigger("Fade");
            
            //fadeToBlack
            //show text that says Day: 31 etc
            //fadeIn
            //send the task to the relevant interactions that causes it, such as add an email, add a document, make the phone ring


            //SceneManager.LoadSceneAsync(); //just to load models
        }
    }

    public void FadeOut()
    {
        _gobacktoChar.exitInteraction();
        //nextDay();
        //getTasks();

    }
}
