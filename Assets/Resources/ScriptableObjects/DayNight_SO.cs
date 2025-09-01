using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct TaskData
{
    public TaskType taskType;
    public InteractionType interactionType;

    [Tooltip("Display only")]
    [TextArea(1, 2)] public string headerOrTitle;

    [Tooltip("Display only")]
    [TextArea(5, 10)] public string text;

    [Tooltip("Audio only")]
    public AudioClip clip;

    [Tooltip("Audio only")]
    public DialogueSequence_SO subDialogues;

    public bool completed;
}


public enum TaskType
{
    Sus,
    Sub
}


public enum InteractionType
{
    Document,
    ReadEmail,
    RingPhone,
    Dial
}

[CreateAssetMenu(fileName = "TaskSet_", menuName = "Game/Task Set")]
public class TaskSet : ScriptableObject
{
    [Header("Tasks")]
    public List<TaskData> tasks = new List<TaskData>();

    public int NumberOfTasks => tasks.Count;

    private void OnValidate()
    { // Sync inspector display
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
