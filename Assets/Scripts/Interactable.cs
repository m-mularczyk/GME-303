using StarterAssets;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField] private GameObject _uiContainer;
    private IInteractable _iinteractable;
    private bool _isInteractable;

    private StarterAssetsInputs _starterAssetsInputs;

    private void Awake()
    {
        _starterAssetsInputs = GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>();

        if( _uiContainer != null )
        _uiContainer.SetActive(false);

        _iinteractable = GetComponent<IInteractable>();
        if (_iinteractable == null)
            Debug.LogError("No IInteractable interface implemented");

        _isInteractable = false;
    }

    private void Update()
    {
        if (_isInteractable && _starterAssetsInputs.interact)
        {
            _iinteractable.Interact();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Show UI
        if (other.CompareTag("Player"))
        {
            _uiContainer.SetActive(true);
            _isInteractable = true;
        }  
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Interact with interactable if E key is pressed
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide UI
            _uiContainer.SetActive(false);
            _isInteractable = false;
        }
    }
}
