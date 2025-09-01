using UnityEngine;
public class Computer : MonoBehaviour, IInteractable
{
    //can interacat
    

    [Header("Change Interactions")]
    [SerializeField] ManagerSwitchInteractions _switchInteractions;
    [SerializeField] Vector3 _interactivePosition;
    [SerializeField] Quaternion _interactiveRotation;
    [SerializeField] bool _interacted = false;
    [Header("Handling Child Interactions")]
    [SerializeField] GameObject _screen;

    [Header("Sounds")]
    [SerializeField] AudioSource _audioSourceComputer;
    [SerializeField] AudioClip _audioIdling;
    //private void OnEnable()
    //{
    //    _interacted = false;
    //    this.GetComponent<Collider>().enabled = true;
    //    _screen.GetComponent<Collider>().enabled = false;
    //}

    private void Update()
    {

        if (_screen.GetComponent<Screen>().HeaderTitle.Count > 0 && _screen.GetComponent<Screen>().HeaderTitle != null && _interacted == false)
        {


            _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
            _screen.GetComponent<Collider>().enabled = true;
            this.GetComponent<Collider>().enabled = true;
            //this.enabled = true;
            //_screen.SetActive(true);
        }
        else
        {

            _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
            //_screen.GetComponent<Collider>().enabled = false;
            this.GetComponent<Collider>().enabled = false;

            //this.enabled = false;
            //_screen.SetActive(false);
        }
    }

    private void Start()
    {
        _interacted = false;
        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
        _screen.GetComponent<Collider>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        this.enabled = false;
        _audioSourceComputer.clip = _audioIdling;
        _audioSourceComputer.Play();
    }
    public void interact()
    {
        // what happens when the player interacts with phone

        //if (_interacted == false)
        //{
        //    _switchInteractions._playerMainCamera.transform.SetParent(this.transform);
        //    _interacted = true;
        //    this.GetComponent<Collider>().enabled = false;
        //    _switchInteractions.characterToInteraction(_interactivePosition, _interactiveRotation);
        //    _screen.GetComponent<Collider>().enabled = true;
        //    Debug.Log("Computer is Interacted");
        //    this.enabled = false;
        //}

        //what happens when the player interacts with phone
        if (_interacted == false)
        {
            _switchInteractions._playerMainCamera.transform.SetParent(this.transform);
            _interacted = true;
            this.GetComponent<Collider>().enabled = false;
            _screen.GetComponent<Collider>().enabled = true;
            _switchInteractions.characterToInteraction(_interactivePosition, _interactiveRotation);
            Debug.Log("Computer is Interacted");
            //this.enabled = false;

        }
    }
}
