using UnityEngine;

public class Phone_Button : MonoBehaviour, IInteractable
{
    [SerializeField] string _numberList;
    [SerializeField] GameObject _CharacterRealParent;
    [SerializeField] GameObject _playerMainCamera;
    private PlayerMovement _playerMovement;
    private Phone _phoneScript;
    private bool _interacted;

    private void OnEnable()
    {
        _interacted = false;
    }
    private void Start()
    {
        _CharacterRealParent = GameObject.Find("Character");
        _playerMainCamera = GameObject.Find("Main Camera");
        _playerMovement = _playerMainCamera.GetComponent<PlayerMovement>();
        _phoneScript = GameObject.Find("Phone_collider").GetComponent<Phone>();
    }

    
    public void interact()
    {
        // Use the GameObject's name to determine which button was pressed
        switch (transform.name)
        {
            case "Button_0":
                Debug.Log("Button_0 pressed!");
 
                break;
            case "Button_01":
                Debug.Log("Button_01 pressed!");
    
                break;
            case "Button_02":
                Debug.Log("Button_02 pressed!");
          
                break;
            case "Button_03":
                Debug.Log("Button_03 pressed!");
     
                break;
            case "Button_04":
                Debug.Log("Button_04 pressed!");
             
                break;
            case "Button_05":
                Debug.Log("Button_05 pressed!");
           
                break;
            case "Button_06":
                Debug.Log("Button_06 pressed!");

                break;
            case "Button_07":
                Debug.Log("Button_07 pressed!");

                break;
            case "Button_08":
                Debug.Log("Button_08 pressed!");

                break;
            case "Button_09":
                Debug.Log("Button_09 pressed!");

                break;
            case "Button_Asterisk":
                Debug.Log("Button_Asterisk pressed!");
                break;
            case "Button_Hash":
                Debug.Log("Button_Hash pressed!");
                break;
            case "Button_ExitPhone":
                Debug.Log("Button_ExitPhone pressed!");
                exitPhone();
                break;
        }
    }

   

    public void exitPhone()
    {
        if (_interacted == false)
        {
            _playerMainCamera.transform.SetParent(_CharacterRealParent.transform);
            _interacted = true;
            _playerMovement.enabled = false;
            //this.GetComponent<Collider>().enabled = false;
            //_phoneScript.enabled = true;
            Debug.Log("Exit Button is Interacted");
        }

    }

    private void LateUpdate()
    {
        if (_interacted == true)
        {
            //set the transorm to lerp till it is Vector3(0, 2, -0.3f)
            Vector3 targetPosition = new Vector3(0, 1.4f, 0);
            //set the rotation transorm to lerp till it is targetRotation)
            Quaternion targetRotation = Quaternion.Euler(0, 0f, 0f);

            _playerMainCamera.transform.localPosition = Vector3.Lerp(_playerMainCamera.transform.localPosition, targetPosition, _phoneScript._cameraSpeed * Time.deltaTime);
            _playerMainCamera.transform.localRotation = Quaternion.Lerp(_playerMainCamera.transform.localRotation, targetRotation, _phoneScript._cameraSpeed * Time.deltaTime);

            if (Vector3.Distance(_playerMainCamera.transform.localPosition, targetPosition) < 0.01f)
            {

                _playerMainCamera.transform.localPosition = targetPosition; // snap exactly
                _playerMainCamera.transform.localRotation = targetRotation;
                _playerMovement.ResetRotation(_playerMainCamera.transform);
                _playerMovement.enabled = true;
                _playerMainCamera.transform.rotation = _playerMainCamera.transform.rotation;

                //Cursor.lockState = CursorLockMode.Confined;
                //Cursor.visible = true;
                _phoneScript.enabled = true;
            }
        }
    }
}
