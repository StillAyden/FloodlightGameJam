using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Phone : MonoBehaviour, IInteractable
{
    [SerializeField] ManagerSwitchInteractions _switchInteractions;
    [SerializeField] Vector3 _interactivePosition;
    [SerializeField] Quaternion _interactiveRotation;
    private bool _interacted = false;

    [Header("Phone Colliders")]
    [SerializeField] GameObject _receiver;
    [SerializeField] GameObject _buttons;


    private void OnEnable()
    {
        _interacted = false;
        this.GetComponent<Collider>().enabled = true;
        _buttons = GameObject.Find("Buttons");
        _receiver = GameObject.Find("Receiver");
        _buttons.SetActive(false);
        _receiver.SetActive(false);
    }
    private void Start()
    {
        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
    }
    public void interact()
    {
        //what happens when the player interacts with phone
        if(_interacted == false)
        {
            _switchInteractions._playerMainCamera.transform.SetParent(this.transform);
            _interacted = true;
            this.GetComponent<Collider>().enabled = false;
            _buttons.SetActive(true);
            _receiver.SetActive(true);
            _switchInteractions.characterToInteraction(_interactivePosition, _interactiveRotation);
            Debug.Log("Phone is Interacted");
            this.enabled = false;
        }
    }

}
