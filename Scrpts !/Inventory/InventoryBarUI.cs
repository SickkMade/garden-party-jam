using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework.Constraints;
using UnityEngine;

public class InventoryBarUI : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventory;
    [SerializeField]
    private GameObject inventoryUIPrefab;

    //vars
    private List<InventorySlotUI> inventoryUIList = new();

    void Start()
    {
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            inventoryUIList.Add(Instantiate(inventoryUIPrefab, this.transform).GetComponent<InventorySlotUI>());
        }
        
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            int quantity = inventory.inventory[i].quantity;
            Sprite sprite = null;
            if (inventory.inventory[i].item != null)
            {
                sprite = inventory.inventory[i].item.itemIcon;
            }
            inventoryUIList[i].SetSlotData(sprite, quantity);
        }
    }
}
