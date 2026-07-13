using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator _anim;
    private bool _isOpen = false;
    [SerializeField] private bool _isLocked;
    [SerializeField] private GameObject _doorControlPanel;
    [SerializeField] private bool _requiresItem;
    [SerializeField] private InventoryManager.AllItems _requiredItem;

    private void Start()
    {
        _anim = GetComponent<Animator>();

        if( _isLocked)
        {
            _doorControlPanel.transform.GetChild(0).gameObject.SetActive(true);
            _doorControlPanel.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            _doorControlPanel.transform.GetChild(0).gameObject.SetActive(false);
            _doorControlPanel.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);

        if (!_isLocked) // Door unlocked
        {
            _isOpen = !_isOpen;
            _anim.SetBool("IsOpen", _isOpen);
            
        }
        else // Door locked
        {
            if (_requiresItem)
            {
                if (HasRequiredItem(_requiredItem))
                {
                    Activate(true);
                }
                else
                {
                    Debug.Log("Check terminal");
                }
            }
        }
    }

    public void Activate(bool isActivated)
    {
        UnlockDoor(isActivated);
    }

    private void UnlockDoor(bool isActivated)
    {
        _isLocked = !isActivated;

        if (_isLocked)
        {
            _doorControlPanel.transform.GetChild(0).gameObject.SetActive(true);
            _doorControlPanel.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            _doorControlPanel.transform.GetChild(0).gameObject.SetActive(false);
            _doorControlPanel.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance.inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
