using UnityEngine;

public class PressurePad : MonoBehaviour
{
    public GameObject[] pressurePadTargets;
    private bool _isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pad"))
        {
            _isActivated = true;
            Debug.Log("Unlocked");

            foreach (GameObject target in pressurePadTargets)
            {
                if (target.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Activate(_isActivated);
                    Debug.Log(target.name + " was activated");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pad"))
        {
            _isActivated = false;
            Debug.Log("Locked");

            foreach (GameObject target in pressurePadTargets)
            {
                if (target.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Activate(_isActivated);
                    Debug.Log(target.name + " was DEactivated");
                }
            }
        }
    }
}
