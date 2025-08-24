using UnityEngine;
public class Computer : MonoBehaviour, IInteractable
{
    [Header("Change Interactions")]
    [SerializeField] ManagerSwitchInteractions _switchInteractions;
    [SerializeField] Vector3 _interactivePosition;
    [SerializeField] Quaternion _interactiveRotation;
    private bool _interacted = false;
    [Header("Handling Child Interactions")]
    [SerializeField] GameObject _screen;
    private void OnEnable()
    {
        _interacted = false;
        this.GetComponent<Collider>().enabled = true;
        _screen = GameObject.Find("Screen");
        _screen.GetComponent<Collider>().enabled = false;
    }
    private void Start()
    {
        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
        _screen = GameObject.Find("Screen");
        _screen.GetComponent<Collider>().enabled = false;
    }
    public void interact()
    {
        // what happens when the player interacts with phone
       
        if (_interacted == false)
        {
            _switchInteractions._playerMainCamera.transform.SetParent(this.transform);
            _interacted = true;
            this.GetComponent<Collider>().enabled = false;
            _switchInteractions.characterToInteraction(_interactivePosition, _interactiveRotation);
            _screen.GetComponent<Collider>().enabled = true;
            Debug.Log("Computer is Interacted");
            this.enabled = false;
        }
       
    }
}
