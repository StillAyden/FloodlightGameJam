using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueSequence_SO : ScriptableObject
{
    public List<DialogueLine> dialogueLines;
}

[System.Serializable]
public struct DialogueLine
{
    public string name;
    [Space(1)]
    [TextArea(5, 10)]public string text;
    [Space(1)]
    public AudioClip clip;
}
