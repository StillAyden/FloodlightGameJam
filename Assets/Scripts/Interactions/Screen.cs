using UnityEngine;

public class Screen : MonoBehaviour, IInteractable
{
    public void interact()
    {
        Debug.Log(transform.name);
        //Have the player click on the screen to acces the menus
    }
}
