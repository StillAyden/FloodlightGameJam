using UnityEngine;

public class Phone_Receiver : MonoBehaviour, IInteractable
{
    public void interact()
    {
        Debug.Log(transform.name);
    }

   

}
