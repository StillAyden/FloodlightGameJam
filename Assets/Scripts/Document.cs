using UnityEngine;

public class Document : MonoBehaviour, IInteractable
{
    public void interact()
    {
        //what happens when the player interacts with phone (from phones perspective)
        //play animation to players face
        Debug.Log("Document is Interacted");
    }
}
