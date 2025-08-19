using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] DialogueSequence_SO[] dialogueSequences;

    [Header("References")]
    [SerializeField] Canvas canvasDialogue; 
    [SerializeField] Text speakerName;
    [SerializeField] Text dialogueText;
    [SerializeField] AudioSource AudioSource;

    [Header("Control variables")]
    int currentIndex = -1;
    Coroutine textGenRoutine = null;

    public void TriggerDialogueSequence(int dialogueId)
    {
        //Reset and display dialogue
        currentIndex = -1;
        dialogueText.text = "";
        speakerName.text = "";

        canvasDialogue.gameObject.SetActive(true);

        //Add any Preparations for Dialogue here e.g. Cinematic Bars, etc.

        StartDialogue(dialogueId);
    }

    void StartDialogue(int dialogueId)
    {
        if (currentIndex < dialogueSequences[dialogueId].dialogueLines.Count - 1 && !AudioSource.isPlaying)
        {
            currentIndex++;
            speakerName.text = dialogueSequences[dialogueId].dialogueLines[currentIndex].name;
            dialogueText.text = dialogueSequences[dialogueId].dialogueLines[currentIndex].text;

            AudioSource.clip = dialogueSequences[dialogueId].dialogueLines[currentIndex].clip;
            AudioSource.Play();
        }
    }

    void SkipDialogueScene()
    {
        canvasDialogue.gameObject.SetActive(false);

        currentIndex = -1;
        dialogueText.text = "";
        speakerName.text = "";

        AudioSource.Stop();
    }

    private void OnDestroy()
    {
        //InputManager.instance.NextLine -= NextLine;
        //InputManager.instance.SkippedSequence -= SkipDialogueSequence;
    }

    private void OnDisable()
    {
        //InputManager.instance.NextLine -= NextLine;
        //InputManager.instance.SkippedSequence -= SkipDialogueSequence;
    }


}


