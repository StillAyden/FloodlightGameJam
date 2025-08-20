using UnityEngine;
public class Computer : MonoBehaviour, IInteractable
{
    [Header("Change Interactions")]
    [SerializeField] ManagerSwitchInteractions _switchInteractions;
    [SerializeField] Vector3 _interactivePosition;
    [SerializeField] Quaternion _interactiveRotation;
    private bool _interacted = false;

    private void OnEnable()
    {
        _interacted = false;
        this.GetComponent<Collider>().enabled = true;
    }
    private void Start()
    {
        _switchInteractions = GameObject.Find("ManagerSwitchInteractions").GetComponent<ManagerSwitchInteractions>();
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
            Debug.Log("Computer is Interacted");
            this.enabled = false;
        }
       
    }
}
