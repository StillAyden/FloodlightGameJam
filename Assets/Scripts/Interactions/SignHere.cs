using UnityEngine;

public class SignHere : MonoBehaviour, IInteractable
{
    public void interact()
    {
        Debug.Log(transform.name);
        //Have the player sign the document
    }
}
