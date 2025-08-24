using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] List<DialogueSequence_SO> dialogueSequences = new List<DialogueSequence_SO>();

    [Header("References")]
    [SerializeField] Canvas canvasDialogue; 
    //[SerializeField] Text speakerName;
    //[SerializeField] Text dialogueText;
    [SerializeField] AudioSource AudioSource;
    [Header("Reder Temp Stuff")]
    [SerializeField] TMP_Text speakerName;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject _currentObject; //the GameObject was added to get the interface of IEndDialogue


    [Header("Control variables")]
    [SerializeField] int currentIndex = -1;
    Coroutine textGenRoutine = null;

    public void TriggerDialogueSequence(DialogueSequence_SO playDialogue, AudioClip playAudio, GameObject _clickedObject) //(int dialogueId, GameObject _clickedObject) //the GameObject was added to get the interface of IEndDialogue
    {
        //Reset and display dialogue
        currentIndex = -1;
        dialogueText.text = "";
        speakerName.text = "";

        canvasDialogue.gameObject.SetActive(true);
        dialogueSequences.Clear();
        dialogueSequences.Add(playDialogue);
        AudioSource.clip = playAudio;
        //Add any Preparations for Dialogue here e.g. Cinematic Bars, etc.
        _currentObject = _clickedObject; //the GameObject was added to get the interface of IEndDialogue

        StartDialogue();
    }

    void StartDialogue() //(int dialogueId)
    {

        if (currentIndex < dialogueSequences[0].dialogueLines.Count - 1 && !AudioSource.isPlaying)
        {
            currentIndex++;
            speakerName.text = dialogueSequences[0].dialogueLines[currentIndex].name;
            dialogueText.text = dialogueSequences[0].dialogueLines[currentIndex].text;

            AudioSource.clip = dialogueSequences[0].dialogueLines[currentIndex].clip;
            AudioSource.Play();
        }

        //if (currentIndex < dialogueSequences[dialogueId].dialogueLines.Count - 1 && !AudioSource.isPlaying)
        //{
        //    currentIndex++;
        //    speakerName.text = dialogueSequences[dialogueId].dialogueLines[currentIndex].name;
        //    dialogueText.text = dialogueSequences[dialogueId].dialogueLines[currentIndex].text;

        //    AudioSource.clip = dialogueSequences[dialogueId].dialogueLines[currentIndex].clip;
        //    AudioSource.Play();
        //}
    }

    public void SkipDialogueScene()
    {
        canvasDialogue.gameObject.SetActive(false);

        currentIndex = -1;
        dialogueText.text = "";
        speakerName.text = "";

        AudioSource.Stop();
        _currentObject.GetComponent<IEndDialogie>().endDialogue(); //the GameObject was added to get the interface of IEndDialogue
    }

    //Reder Added the Next Line
    public void NextLine()
    {
        //testing next line
        
        if (currentIndex != dialogueSequences[0].dialogueLines.Count-1)
        {
            if (!AudioSource.isPlaying)
            {
                StartDialogue(); //StartDialogue(0);
                Debug.Log("Next Line");
            }
           
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


