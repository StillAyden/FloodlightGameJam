using UnityEngine;

/*
To use inputs in other scripts do the following on a SINGLE UPDATED METHOD [such as Start()]:
      "InputManager.Instance.Interacted += Interact()"
"Interact()" will be the method that is executed when the interact button is pressed
Remember to Unsubscribe somewhere too: "InputManager.Instance.Interacted += Interact()"
*/

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private InputSystem_Actions Inputs;

    [Header("Axis Input")]
    public Vector2 lookAxis;

    //Player Inputs
    public delegate void PlayerHandler();
    public event PlayerHandler Interacted;

    //UI Inputs
    public delegate void UserInterfaceHandler();
    public event UserInterfaceHandler NavigatedUp;
    public event UserInterfaceHandler NavigatedDown;
    public event UserInterfaceHandler NavigatedLeft;
    public event UserInterfaceHandler NavigatedRight;
    public event UserInterfaceHandler Entered;
    public event UserInterfaceHandler Returned;

    //Dialogue Inputs

    //Computer Inputs

    private void Awake()
    {
        //Instance of this object referenced anywhere using "InputManager.Instance"
        Instance = this;

        //New (and ONLY) instance of the inputs
        Inputs = new InputSystem_Actions();
    }

    private void Start()
    {
        //Player Subscriptions
        Inputs.Player.Interact.performed += x => Interact();

        //UI Subscriptions
        //Inputs.UI.NavigateUp.performed += x => NavigateUp();
        //Inputs.UI.NavigateDown.performed += x => NavigateDown();
        //Inputs.UI.NavigateLeft.performed += x => NavigateLeft();
        //Inputs.UI.NavigateRight.performed += x => NavigateRight();
        //Inputs.UI.Enter.performed += x => Enter();
        //Inputs.UI.Return.performed += x => Return();

    }

    private void Update()
    {
        lookAxis = GetLookAxis();
    }

    #region Player Control
    public void SetPlayerControl(bool active)
    {
        if (active)
        {
            SetCursorActive(false);
            Inputs.Player.Enable();
            Inputs.UI.Disable();
        }

    }

    private void Interact()
    {
        Interacted?.Invoke();
    }

    Vector2 GetLookAxis()
    {
        float x = Inputs.Player.Look.ReadValue<Vector2>().x;
        float y = Inputs.Player.Look.ReadValue<Vector2>().y;

        return new Vector2(x, y);
    }
    #endregion


    public void SetCursorActive(bool active)
    {
        if (active == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void OnDestroy()
    {
        //Unsubscriptions
        Inputs.Player.Interact.performed -= x => Interact();
    }
}
