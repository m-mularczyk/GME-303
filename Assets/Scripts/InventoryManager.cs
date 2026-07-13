using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<AllItems> inventoryItems = new List<AllItems>();


    private void Awake()
    {
        Instance = this;
    }

    public enum AllItems
    {
        KeycardA,
        KeycardB, 
        KeycardC,
        KeycardD,
    }

    public void AddItems(AllItems item)
    {
        if (!inventoryItems.Contains(item))
        {
            inventoryItems.Add(item);
        }
    }
}
