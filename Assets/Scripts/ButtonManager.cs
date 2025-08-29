using NUnit.Framework;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool _pressSpecificButton;
    public int _pressSpecificButtonIndex = -1;
    public string currentPhoneNumber;
    [SerializeField] GameObject _dialogueStuff;

    [SerializeField] PlayerMovement _enableMovement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNumber(int numberPressed)
    {
        if (!_pressSpecificButton)
        {
            //if (//get length of character < 10)
            //{

            //}
            currentPhoneNumber = currentPhoneNumber + numberPressed;
        }
        else
        {
            if (numberPressed == _pressSpecificButtonIndex)
            {
                _pressSpecificButton = false;
                _pressSpecificButtonIndex = -1;
                //_dialogueStuff.SetActive(true);
                _dialogueStuff.GetComponent<CanvasGroup>().alpha = 1;
                _dialogueStuff.GetComponent<CanvasGroup>().interactable = true;
                _dialogueStuff.GetComponent<CanvasGroup>().blocksRaycasts = true;
                _enableMovement.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
    }
}
