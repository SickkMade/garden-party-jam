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
    public List<InventorySlotUI> InventoryUIList => inventoryUIList;

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
            InventorySlot inventorySlot = inventory.inventory[i];
            inventoryUIList[i].SetSlotData(inventorySlot);  
        }
    }
}
