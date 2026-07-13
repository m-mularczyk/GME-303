using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    public GameObject[] targets;
    public bool _isPoweredUp;

    public void Interact()
    {
        foreach (GameObject target in targets)
        {
            if(target.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                //interactable.Interact();
                Debug.Log(target.name + " is now powered up");
                interactable.Activate(_isPoweredUp);
            }
        }
    }

    public void Activate(bool isActivated)
    {

    }
}
