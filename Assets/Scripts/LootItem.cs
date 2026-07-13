using UnityEngine;

public class LootItem : MonoBehaviour, IInteractable
{

    public InventoryManager.AllItems _itemType;

    public void Interact()
    {
        InventoryManager.Instance.AddItems(_itemType);

        Destroy(gameObject);
    }

    public void Activate(bool isActivated)
    {

    }
}
