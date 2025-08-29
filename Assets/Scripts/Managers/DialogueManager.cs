using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputControlScheme.MatchResult;

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

    [Header("Press what?")]
    [SerializeField] ButtonManager _setItTrue;
    [SerializeField] PlayerMovement _enableMovement;

    [Header("Control variables")]
    [SerializeField] int currentIndex = -1;
    Coroutine textGenRoutine = null;

    public void TriggerDialogueSequence(DialogueSequence_SO playDialogue, GameObject _clickedObject) //AudioClip playAudio, //(int dialogueId, GameObject _clickedObject) //the GameObject was added to get the interface of IEndDialogue
    {
        //Reset and display dialogue
        currentIndex = -1;
        dialogueText.text = "";
        speakerName.text = "";

        canvasDialogue.gameObject.SetActive(true);
        dialogueSequences.Clear();
        dialogueSequences.Add(playDialogue);
        //AudioSource.clip = playAudio;
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
                StartDialogue();

                //StartDialogue(0);
                //hide if the dialogue mentions a button to be pressed 
                //if (dialogueText.text.Contains("PRESS"))
                //{
                //    // Hide the dialogue canvas
                //    canvasDialogue.gameObject.SetActive(false);

                //    switch (dialogueText.text)
                //    {
                //        case "PRESS 1":
                //            Debug.Log("Pressed 1 triggered");
                //            // TODO: Put logic for PRESS 1 here
                //            break;

                //        case "PRESS 2":
                //            Debug.Log("Pressed 2 triggered");
                //            // TODO: Put logic for PRESS 2 here
                //            break;

                //        case "PRESS 3":
                //            Debug.Log("Pressed 3 triggered");
                //            // TODO: Put logic for PRESS 3 here
                //            break;

                //        default:
                //            Debug.Log("Unrecognized PRESS command: " + dialogueText.text);
                //            break;
                //    }

                //    //// Show the button
                //    //canvasDialogue.gameObject.SetActive(true);
                //}

                // Look for "PRESS <number>"

                //wait until audio is finished playing
                System.Text.RegularExpressions.Match match = Regex.Match(dialogueText.text, @"PRESS\s+(\d+)"); //this is new to me so yeah
                Debug.Log("What is the currently:" +match);
                if (match.Success)
                {
                   StartCoroutine(waitTileAudioIsFinised());
                }
                

                Debug.Log("Next Line");
            }
           
        }
        else
        {
            SkipDialogueScene();
        }
    }


    IEnumerator waitTileAudioIsFinised()
    {
        // Wait until the audio is done playing
        if (AudioSource != null)
        {
            while (AudioSource.isPlaying)
            {
                yield return null; // wait for the next frame and check again
            }
        }

     
            canvasDialogue.gameObject.SetActive(false);

            _enableMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            System.Text.RegularExpressions.Match match = Regex.Match(dialogueText.text, @"PRESS\s+(\d+)");
            int pressNumber = int.Parse(match.Groups[1].Value);

            switch (pressNumber)
            {
                case 0:
                    Debug.Log("Action for PRESS 0");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 0;
                    break;
                case 1:
                    Debug.Log("Action for PRESS 1");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 1;
                    break;
                case 2:
                    Debug.Log("Action for PRESS 2");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 2;
                    break;
                case 3:
                    Debug.Log("Action for PRESS 3");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 3;
                    break;
                case 4:
                    Debug.Log("Action for PRESS 4");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 4;
                    break;
                case 5:
                    Debug.Log("Action for PRESS 5");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 5;
                    break;
                case 6:
                    Debug.Log("Action for PRESS 6");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 6;
                    break;
                case 7:
                    Debug.Log("Action for PRESS 7");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 7;
                    break;
                case 8:
                    Debug.Log("Action for PRESS 8");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 8;
                    break;
                case 9:
                    Debug.Log("Action for PRESS 9");
                    _setItTrue._pressSpecificButton = true;
                    _setItTrue._pressSpecificButtonIndex = 9;
                    break;

            }
        StopCoroutine(waitTileAudioIsFinised());
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


