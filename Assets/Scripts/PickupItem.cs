using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);

        Destroy(gameObject);
    }

    public void Activate(bool isActivated)
    {
        
    }
}
