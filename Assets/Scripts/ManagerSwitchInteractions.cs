using UnityEngine;

public class ManagerSwitchInteractions : MonoBehaviour
{
    [Header("Player Stuff")]
    public GameObject _playerMainCamera;
    public PlayerMovement _playerMovement;
    [SerializeField] GameObject _characterRealParent;
    [SerializeField, Range(0, 5)] public float _cameraSpeed;
    [SerializeField] Vector3 _newPosition;
    [SerializeField] Quaternion _newRotation;

    [Header("Interactive Stuff")]
    [SerializeField] bool charToInt = false;
    [SerializeField] bool intToChar = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _playerMainCamera = GameObject.Find("Main Camera");
        _characterRealParent = GameObject.Find("Character");
        _playerMovement = _playerMainCamera.GetComponent<PlayerMovement>(); ;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (charToInt == true)
        {
            //set the transorm to lerp till it is Vector3(0, 2, -0.3f)
            Vector3 targetPosition = _newPosition;
            //set the rotation transorm to lerp till it is targetRotation)
            Quaternion targetRotation = _newRotation;

            _playerMainCamera.transform.localPosition = Vector3.Lerp(_playerMainCamera.transform.localPosition, targetPosition, _cameraSpeed * Time.deltaTime);
            _playerMainCamera.transform.localRotation = Quaternion.Lerp(_playerMainCamera.transform.localRotation, targetRotation, _cameraSpeed * Time.deltaTime);

            if (Vector3.Distance(_playerMainCamera.transform.localPosition, targetPosition) < 0.01f)
            {

                _playerMainCamera.transform.localPosition = targetPosition; // snap exactly
                _playerMainCamera.transform.localRotation = targetRotation;
                _playerMovement.ResetRotation(_playerMainCamera.transform);
                charToInt = false;
                _playerMovement.enabled = true;
                _playerMainCamera.transform.rotation = _playerMainCamera.transform.rotation;
                //Cursor.lockState = CursorLockMode.Confined;
                //Cursor.visible = true;
                
            }
        }

        if(intToChar == true)
        {
            //set the transorm to lerp till it is Vector3(0, 2, -0.3f)
            Vector3 targetPosition = _newPosition;
            //set the rotation transorm to lerp till it is targetRotation)
            Quaternion targetRotation = _newRotation;

            _playerMainCamera.transform.localPosition = Vector3.Lerp(_playerMainCamera.transform.localPosition, targetPosition, _cameraSpeed * Time.deltaTime);
            _playerMainCamera.transform.localRotation = Quaternion.Lerp(_playerMainCamera.transform.localRotation, targetRotation, _cameraSpeed * Time.deltaTime);

            if (Vector3.Distance(_playerMainCamera.transform.localPosition, targetPosition) < 0.01f)
            {
                _playerMainCamera.transform.localPosition = targetPosition; // snap exactly
                _playerMainCamera.transform.localRotation = targetRotation; // snap exactly
                _playerMovement.ResetRotation(_playerMainCamera.transform);
                _playerMovement.enabled = true;
                _playerMainCamera.transform.rotation = _playerMainCamera.transform.rotation;
                intToChar = false;
                //Cursor.lockState = CursorLockMode.Confined;
                //Cursor.visible = true;
            }
        }
    }

    public void characterToInteraction(Vector3 _targetPosition, Quaternion _targetRotation)
    {
        _newPosition = _targetPosition;
        _newRotation = _targetRotation;
        charToInt = true;
    }

    public void InteractionToCharacter()
    {
        _playerMovement.enabled = false;
        _newPosition = new Vector3(0,1.4f,0);
        _newRotation = _characterRealParent.transform.localRotation;
        _playerMainCamera.transform.SetParent(_characterRealParent.transform);
        intToChar = true;
    }
}
