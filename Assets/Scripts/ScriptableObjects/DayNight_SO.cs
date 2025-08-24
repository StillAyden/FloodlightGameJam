using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


[System.Serializable]
public struct TaskData
{
    public InteractionType interactionType;
    [Tooltip("use this only for Display Purposes")]
    [TextArea(1, 2)] public string headerOrTitle; //use this only for Display Purposes
    [Tooltip("use this only for Display Purposes")]
    [TextArea(5, 10)] public string text; //use this only for Display Purposes

    [Tooltip("use this only for Audio purposes")]
    public AudioClip clip; //use this only for Audio purposes
    [Tooltip("use this only for Audio purposes")]
    public DialogueSequence_SO subDialogues; //use this only for Audio purposes

    public bool completed;
}

[System.Serializable]
public struct SusTasks
{
    public InteractionType interactionType;
    //use this only for Audio purposes
    [Tooltip("use this only for Audio purposes")]
    public DialogueSequence_SO _susDialouges;
    [Tooltip("use this only for Display Purposes")]
    [TextArea(1, 2)] public string headerOrTitle; //use this only for Display Purposes
    [Tooltip("use this only for Display Purposes")]
    [TextArea(5, 10)] public string text; //use this only for Display Purposes

    //[Tooltip("use this only for Audio purposes")]
    //public AudioClip clip; //use this only for Audio purposes
    //[Tooltip("use this only for Audio purposes")]
    //public DialogueSequence_SO mainDialogues; //use this only for Audio purposes

    public bool completed;
}

    public enum InteractionType
{
    Document,
    ReadEmail,
    RingPhone
}

[CreateAssetMenu(fileName = "Task_Which Act?", menuName = "Game/Task Set")] 
public class TaskSet : ScriptableObject
{
    [Header("Tasks")]
    public int numberOfTasks;
    public List<TaskData> subTasks = new List<TaskData>();
    public List<SusTasks> susTasks = new List<SusTasks>(); 

    private void OnValidate()
    {
        // Keep numberOfTasks in sync with list count
        numberOfTasks = subTasks.Count;
    }
}
