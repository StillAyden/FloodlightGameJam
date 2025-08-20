using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] DialogueSequence_SO[] dialogueSequences;

    [Header("References")]
    [SerializeField] Canvas canvasDialogue; 
    //[SerializeField] Text speakerName;
    //[SerializeField] Text dialogueText;
    [SerializeField] AudioSource AudioSource;
    [Header("Reder Temp Stuff")]
    [SerializeField] TMP_Text speakerName;
    [SerializeField] TMP_Text dialogueText;


    [Header("Control variables")]
    [SerializeField] int currentIndex = -1;
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

    public void SkipDialogueScene()
    {
        canvasDialogue.gameObject.SetActive(false);

        currentIndex = -1;
        dialogueText.text = "";
        speakerName.text = "";

        AudioSource.Stop();
    }

    //Reder Added the Next Line
    public void NextLine()
    {
        //testing next line
        
        if (currentIndex != dialogueSequences[0].dialogueLines.Count-1)
        {
            StartDialogue(0);
            Debug.Log("Next Line");
        }
        else
        {
            SkipDialogueScene();
        }
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


