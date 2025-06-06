using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Player Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> inventory = new(9);
}
