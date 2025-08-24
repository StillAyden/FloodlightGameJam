using UnityEngine;

public class SignHere : MonoBehaviour, IInteractable
{
    [Header("Sounds")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClipDocument;
    public void interact()
    {
        Debug.Log(transform.name);
        // send an event to the DayNight Manager to say task is completed
        _audioSource.clip = _audioClipDocument;
        _audioSource.Play();
        //Have the player sign the document
        //an animation of signing is happening
        //document goes away and you are shifted back to the character
    }
}
