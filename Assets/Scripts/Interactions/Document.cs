using TMPro;
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
    [SerializeField] GameObject _wholeDocument;
    [SerializeField] Animator documentAnimator;
    [SerializeField] GameObject _inDocuments;

    [Header("Document Text Added")]
    [SerializeField] TMP_Text _headerText;
    [SerializeField] TMP_Text _bodyText;

    //private void OnEnable()
    //{
    //    if (_documentSign.GetComponent<SignHere>().HeaderTitle.Count > 0 && _documentSign.GetComponent<SignHere>().HeaderTitle != null)
    //    {
    //        _interacted = false;
    //        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
    //        _documentSign = GameObject.Find("SignHere");
    //        _documentSign.GetComponent<Collider>().enabled = false;
    //        this.GetComponent<Collider>().enabled = false;
    //        this.enabled = true;
    //    }
    //    else
    //    {
    //        _interacted = false;
    //        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
    //        _documentSign = GameObject.Find("SignHere");
    //        _documentSign.GetComponent<Collider>().enabled = false;
    //        this.GetComponent<Collider>().enabled = false;
    //        this.enabled = false;
    //    }


    //}
    private void Start()
    {
        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
        _documentSign = GameObject.Find("SignHere");
        _wholeDocument = GameObject.Find("Document_Animation");
        //_documentSign.GetComponent<Collider>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }

    private void Update()
    {
        if (_documentSign.GetComponent<SignHere>().HeaderTitle.Count > 0 && _documentSign.GetComponent<SignHere>().HeaderTitle != null)
        {
            _interacted = false;
            _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
            _documentSign = GameObject.Find("SignHere");
            _documentSign.GetComponent<Collider>().enabled = true;
            //_wholeDocument.gameObject.SetActive(true);
            this.GetComponent<Collider>().enabled = true;
            //this.enabled = true;
            _inDocuments.SetActive(true);
        }
        else
        {
            _interacted = false;
            _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
            _documentSign = GameObject.Find("SignHere");
            _documentSign.GetComponent<Collider>().enabled = false;
            //_wholeDocument.gameObject.SetActive(false);
            this.GetComponent<Collider>().enabled = false;
            //this.enabled = false;
            _inDocuments.SetActive(false);
        }
    }
    public void interact()
    {
        //what happens when the player interacts with phone
        if (_interacted == false)
        {
            documentAnimator.SetTrigger("BringDocument");
            _headerText.text = _documentSign.GetComponent<SignHere>().HeaderTitle[0];
            _bodyText.text = _documentSign.GetComponent<SignHere>().bodyText[0];
            _switchInteractions._playerMainCamera.transform.SetParent(this.transform);
            _interacted = true;
            this.GetComponent<Collider>().enabled = false;
            _switchInteractions.characterToInteraction(_interactivePosition, _interactiveRotation);
            _documentSign.gameObject.SetActive(true);
            _documentSign.GetComponent<Collider>().enabled = true;

            if (_documentSign.GetComponent<SignHere>().HeaderTitle.Count > 1)
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
