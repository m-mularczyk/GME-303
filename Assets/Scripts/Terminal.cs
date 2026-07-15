using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    public GameObject[] targets;
    public bool _isActivated;

    public int terminalFloorIndex;

    public void Interact()
    {
        foreach (GameObject target in targets)
        {
            if(target.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                //interactable.Interact();
                Debug.Log(target.name + " is now powered up");

                interactable.Activate(_isActivated);

                if(target.TryGetComponent<Elevator>(out Elevator elevator))
                {
                    elevator.ChooseFloor(terminalFloorIndex);
                }
            }
        }
    }

    public void Activate(bool isActivated)
    {
        this._isActivated = isActivated;
    }
}
