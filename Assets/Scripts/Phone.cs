using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Phone : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject _playerMainCamera;
    private PlayerMovement _playerMovement;
    [SerializeField] GameObject _CharacterRealParent;
    [SerializeField, Range(0, 5)] float _cameraSpeed;
    private bool _interacted = false;

    [Header("Phone Colliders")]
    [SerializeField] GameObject _receiver;
    [SerializeField] GameObject _buttons;


    private void OnEnable()
    {
        _interacted = false;
        this.GetComponent<Collider>().enabled = true;
    }
    private void Start()
    {
        _playerMainCamera = GameObject.Find("Main Camera");
        _playerMovement = _playerMainCamera.GetComponent<PlayerMovement>(); 
        _CharacterRealParent = GameObject.Find("Character");
        _buttons = GameObject.Find("Receiver");
        _receiver = GameObject.Find("Buttons");

        _buttons.SetActive(false);
        _receiver.SetActive(false);
    }
    public void interact()
    {
        //what happens when the player interacts with phone (from phones perspective)
        //set the camera parent of the phone
        if(_interacted == false)
        {
            _playerMainCamera.transform.SetParent(this.transform);
            _interacted = true;
            _playerMovement.enabled = false;
            this.GetComponent<Collider>().enabled = false;
            _buttons.SetActive(true);
            _receiver.SetActive(true);
            Debug.Log("Phone is Interacted");
        }
    }

    private void LateUpdate()
    {
        if (_interacted == true)
        {
            //set the transorm to lerp till it is Vector3(0, 2, -0.3f)
            Vector3 targetPosition = new Vector3(0.15f, 1.2f, -0.5f);
            //set the rotation transorm to lerp till it is targetRotation)
            Quaternion targetRotation = Quaternion.Euler(62, 0f, 0f);

            _playerMainCamera.transform.localPosition = Vector3.Lerp(_playerMainCamera.transform.localPosition, targetPosition, _cameraSpeed * Time.deltaTime);
            _playerMainCamera.transform.localRotation = Quaternion.Lerp(_playerMainCamera.transform.localRotation, targetRotation, _cameraSpeed * Time.deltaTime);
            
            if (Vector3.Distance(_playerMainCamera.transform.localPosition, targetPosition) < 0.01f)
            {
                
                _playerMainCamera.transform.localPosition = targetPosition; // snap exactly
                _playerMainCamera.transform.localRotation = targetRotation;
                _playerMovement.ResetRotation(_playerMainCamera.transform);
                _playerMovement.enabled = true;
                _playerMainCamera.transform.rotation = _playerMainCamera.transform.rotation;

                //Cursor.lockState = CursorLockMode.Confined;
                //Cursor.visible = true;
                this.enabled = false; // disable script
            }
        }
    }

}
