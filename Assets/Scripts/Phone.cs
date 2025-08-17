using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Phone : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject _playerMainCamera;
    [SerializeField] GameObject _CharacterRealParent;
    [SerializeField, Range(0,5)] float _camerSpeed;
    private bool _interacted = false;

    private void Start()
    {
        _playerMainCamera = GameObject.Find("Main Camera");
        _CharacterRealParent = GameObject.Find("Character");
    }
    public void interact()
    {
        //what happens when the player interacts with phone (from phones perspective)
        //set the camera parent of the phone
        if(_interacted == false)
        {
            _playerMainCamera.transform.SetParent(this.transform);
            _interacted = true;
            //this.GetComponent<Collider>().enabled = false;
            Debug.Log("Phone is Interacted");
        }
        else
        {
            _playerMainCamera.transform.SetParent(_CharacterRealParent.transform);
            _interacted = false;
            //this.GetComponent<Collider>().enabled = true;
            Debug.Log("Phone is Exited");
        }
       


    }

    private void LateUpdate()
    {
        if (_interacted == true)
        {
            //set the transorm to lerp till it is Vector3(0, 2, -0.3f)
            Vector3 targetPosition = new Vector3(0, 2, -0.3f);
            _playerMainCamera.transform.localPosition = Vector3.Lerp(_playerMainCamera.transform.localPosition, targetPosition, _camerSpeed * Time.deltaTime); // 5 = speed factor, adjust as needed
            if (Vector3.Distance(_playerMainCamera.transform.localPosition, targetPosition) < 0.01f)
            {
                _playerMainCamera.transform.localPosition = targetPosition; // snap exactly
                //this.enabled = false; // disable script
            }
        }
        else
        {
            //set the transorm to lerp till it is Vector3(0, 2, -0.3f)
            Vector3 targetPosition = new Vector3(0, 1.4f, 0);
            _playerMainCamera.transform.localPosition = Vector3.Lerp(_playerMainCamera.transform.localPosition, targetPosition, _camerSpeed * Time.deltaTime); // 5 = speed factor, adjust as needed
            if (Vector3.Distance(_playerMainCamera.transform.localPosition, targetPosition) < 0.01f)
            {
                _playerMainCamera.transform.localPosition = targetPosition; // snap exactly
                //this.enabled = false; // disable script
            }
        }
        
    }

}
