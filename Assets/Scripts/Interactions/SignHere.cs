using UnityEngine;

public class SignHere : MonoBehaviour, IInteractable
{
    public void interact()
    {
        Debug.Log(transform.name);
        //Have the player sign the document
        //an animation of signing is happening
        //document goes away and you are shifted back to the character
    }
}
