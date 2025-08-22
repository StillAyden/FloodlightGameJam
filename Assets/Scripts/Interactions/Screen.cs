using UnityEngine;

public class Screen : MonoBehaviour, IInteractable
{
    [Header("Sounds")]
    [SerializeField] AudioSource _audioSourceComputer;
    [SerializeField] AudioSource _audioSourceMail;
    [SerializeField] AudioClip _audioIdling;
    [SerializeField] AudioClip _audioReceiveMail;

    public void Start()
    {
        _audioSourceComputer.clip = _audioIdling;
        _audioSourceComputer.Play();

        ReceiveMail();
    }
    public void interact()
    {
        Debug.Log(transform.name);
        //Have the player click on the screen to access the menus


    }

    public void ReceiveMail() //maybe something can trigger the receiving mails from something
    {
        _audioSourceMail.clip = _audioReceiveMail;
        _audioSourceMail.Play();
    }
}
