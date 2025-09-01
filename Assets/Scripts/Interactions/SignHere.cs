using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignHere : MonoBehaviour, IInteractable
{
    [SerializeField] TaskManager _dayNightManager;
    [SerializeField] Animator documentAnimator;
    
    [SerializeField] GameObject _outDocuments;
    [SerializeField] Document _documentManager;

    [Header("Sounds")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClipDocument;

    [Header("Document Sub Tasks")]
    public List<string> HeaderTitle = new List<string>();
    public List<string> bodyText = new List<string>();
    public List<int> taskNumber = new List<int>();

   


    private void Start()
    {
        _dayNightManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();
        _documentManager = GameObject.Find("Document_collider").GetComponent<Document>();
        _outDocuments.SetActive(false);
    }

    public void Update()
    {
        
    }

    public void interact()
    {
        if (HeaderTitle.Count == 1)
        {
            this.enabled = false;
            _outDocuments.SetActive(false);
        }

        Debug.Log(transform.name);
        // send an event to the DayNight Manager to say task is completed
        if (HeaderTitle.Count > 0)
        {

            _outDocuments.SetActive(true);
            //_documentManager.enabled = true;
            _dayNightManager.taskCompleted(taskNumber[0]);
            HeaderTitle.Remove(HeaderTitle[0]);
            bodyText.Remove(bodyText[0]);
            taskNumber.Remove(taskNumber[0]);
            this.enabled = false;
        }

        _audioSource.clip = _audioClipDocument;
        _audioSource.Play();
        //documentAnimator.SetTrigger("BringDocument");
        documentAnimator.SetTrigger("SendDocument");
        //Have the player sign the document
        //an animation of signing is happening
        //document goes away and you are shifted back to the character
    }

    public void SetdocumentTasks(string Header, string BodyText, int taskValue)
    {
        this.gameObject.SetActive(true);
        HeaderTitle.Add(Header);
        bodyText.Add(BodyText);
        taskNumber.Add(taskValue);
    }
}
