using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    [SerializeField]
    private InventorySO allItemsSO;
    private Dictionary<string, GameObject> instantiatedHoldableItemsDict = new();
    private GameObject weaponHolder;
    private GameObject currentItem;
    [SerializeField]
    private InventorySO currentItemSO;

    void Start()
    {
        //create weapon holder and make child of player
        weaponHolder = new GameObject("WeaponHolder");
        weaponHolder.transform.parent = this.transform;


        //TODO REMAKE PREFAB JUST IN THE ACTUAL ITEM TO SAVE THIS HEADACHE
        for (int i = 0; i < allItemsSO.inventory.Count; i++)
        {
            GameObject instantiatedItem = null;
            if (allItemsSO.inventory[i].item.itemType == ItemType.Placeable)
            {
                instantiatedItem = Instantiate(allItemsSO.inventory[i].item.placeableItem.placeableItemPrefab, weaponHolder.transform);
            }
            else if (allItemsSO.inventory[i].item.itemType == ItemType.Weapon)
            {
                instantiatedItem = Instantiate(allItemsSO.inventory[i].item.weaponItem.weaponPrefab, weaponHolder.transform);
            }
            else
            {
                Debug.LogError("TRYING TO INSTANTIATE ITEM WITH INVALID ITEM TYPE");
            }
            instantiatedHoldableItemsDict.Add(allItemsSO.inventory[i].item.itemName, instantiatedItem);
            instantiatedItem.SetActive(false);
        }
    }

    public void ChangeHeldItem()
    {
        if (currentItem != null)
        {
            currentItem.SetActive(false);
        }
        if (currentItemSO.inventory[0].item == null) return;
        currentItem = instantiatedHoldableItemsDict[currentItemSO.inventory[0].item.itemName];
        currentItem.SetActive(true);
    } 
} 
