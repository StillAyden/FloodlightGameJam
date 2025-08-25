using NUnit.Framework;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] TaskSet[] _actsOrChapters;
    [SerializeField] int getNumberOfDays;
    [SerializeField] int currentDay;
    [SerializeField] bool tasksCompleted = false;
    [SerializeField] int getNumberOfTasks;

    [Header("Send Tasks")]
    [SerializeField] private Phone_Receiver phoneManager;
    [SerializeField] private SignHere documentManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        //send the task to the relevant interactions that causes it, such as add an email, add a document, add a voicemail
        getTasks();
    }

    public void getTasks()
    {
        for (int i = 0; i < getNumberOfTasks; i++)
        {
            var task = _actsOrChapters[currentDay].tasks[i];
            //Debug.Log("Task has added: "+ task.interactionType);

            // switch based on InteractionType
            switch (task.interactionType)
            {
                case InteractionType.Document:
                    Debug.Log("Add Document: " + task.headerOrTitle);
                    // TODO: add more documents to the Document system

                    documentManager.SetdocumentTasks(task.headerOrTitle, task.text, i);

                    //testing
                    Debug.Log("Task Number: " + i + " Header: " + task.headerOrTitle + " Body: " + task.text);

                    //send the current i to relevant script this will help for completing tasks

                    break;

                case InteractionType.ReadEmail:
                    Debug.Log("Add Email: " + task.headerOrTitle);
                    // TODO: add emails to your system

                    //testing
                    Debug.Log("Task Number: " + i + " Header: " + task.headerOrTitle + " Body: " + task.text);

                    //send the current i to relevant script this will help for completing tasks
                    break;

                case InteractionType.RingPhone:
                    Debug.Log("Make Phone Ring, clip: " + task.clip);
                    // TODO: add the clip, dialogue and taskValue to make a voice mail
                    if (task.taskType == TaskType.Sub)
                    {
                        phoneManager.SetphoneTasks(task.clip, task.subDialogues, i);
                    }
                    else
                    {
                        Debug.Log("It is a Sus task");
                    }

                    //testing
                    Debug.Log("Task Number: " + i + " Header: " + task.clip.name + " Body: " + task.subDialogues.name);

                    //send the current i to relevant script this will help for completing tasks
                    break;
            }/////////
        }
    }

    public void taskCompleted(int whichTaskCompleted)
    {
        var task = _actsOrChapters[currentDay].tasks[whichTaskCompleted];
        task.completed = true;
        for (int i = 0; i < getNumberOfTasks; i++)
        {
            if (_actsOrChapters[currentDay].tasks[i].completed == true)
            {
                //change new day
                tasksCompleted = true;
                nextDay();
            }
            else
            {
                tasksCompleted = false;
            }
        }

        //activate a SUS task based on certain scenarios

    }

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
            //fadeToBlack
            //show text that says Day: 31 etc
            //fadeIn
            //send the task to the relevant interactions that causes it, such as add an email, add a document, make the phone ring
            getTasks();

            //SceneManager.LoadSceneAsync(); //just to load models
        }
    }
}
