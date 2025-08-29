using UnityEngine;

public class Document : MonoBehaviour, IInteractable
{
    [Header("Change Interactions")]
    [SerializeField] ManagerSwitchInteractions _switchInteractions;
    [SerializeField] Vector3 _interactivePosition;
    [SerializeField] Quaternion _interactiveRotation;
    private bool _interacted = false;

    [Header("Handling Child Interactions")]
    [SerializeField] GameObject _documentSign;
    private void OnEnable()
    {
        _interacted = false;
        this.GetComponent<Collider>().enabled = true;
        _documentSign = GameObject.Find("SignHere");
        _documentSign.GetComponent<Collider>().enabled = false;
    }
    private void Start()
    {
        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
        _documentSign = GameObject.Find("SignHere");
        _documentSign.GetComponent<Collider>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
    public void interact()
    {
        //what happens when the player interacts with phone
        if (_interacted == false)
        {
            _switchInteractions._playerMainCamera.transform.SetParent(this.transform);
            _interacted = true;
            this.GetComponent<Collider>().enabled = false;
            _switchInteractions.characterToInteraction(_interactivePosition, _interactiveRotation);
            if (_documentSign.GetComponent<SignHere>().HeaderTitle.Count>0)
            {
                _documentSign.GetComponent<Collider>().enabled = true;
                _documentSign.gameObject.SetActive(true);
            }
            else
            {
                _documentSign.gameObject.SetActive(false);
            }


                Debug.Log("Document is Interacted");
            this.enabled = false;
        }
       
    }
}
