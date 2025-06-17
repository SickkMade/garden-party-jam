using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryBarUI))]
public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InputReader inputReader;
    private InventoryBarUI inventoryBarUI;
    private List<InventorySlotUI> inventoryList;
    private HotbarSelected currentHotbarSlot = HotbarSelected.one;
    private HotbarSelected lastHotbarSlot;
    private InventorySO currentItem;
    private float scrollTimer;
    [SerializeField]
    private float scrollDelay = 0.05f;
    [SerializeField]
    private float scrollThreshold = 0.1f;

    private void Start()
    {
        inventoryBarUI = GetComponent<InventoryBarUI>();
        inventoryList = inventoryBarUI.InventoryUIList;

        inputReader.hotbar1 += OnHotbar;
        inputReader.hotbar2 += OnHotbar;
        inputReader.hotbar3 += OnHotbar;
        inputReader.hotbar4 += OnHotbar;
        inputReader.hotbar5 += OnHotbar;
        inputReader.hotbar6 += OnHotbar;
        inputReader.hotbar7 += OnHotbar;
        inputReader.hotbar8 += OnHotbar;
        inputReader.hotbar9 += OnHotbar;

        inputReader.hotbarScroll += OnScrollWheel;

        if (inventoryList.Count != Enum.GetValues(typeof(HotbarSelected)).Length)
        {
            Debug.LogWarning("Inventory list size does not match number of Hotbar slots!");
        }
    }
    private void OnHotbar(int hotbarNum)
    {
        if (hotbarNum < 1 || hotbarNum > inventoryList.Count) return;
        SetCurrentHotbar((HotbarSelected)(hotbarNum - 1));
    }
    private void SetCurrentHotbar(HotbarSelected newHotbarSlot)
    {
        lastHotbarSlot = currentHotbarSlot;
        currentHotbarSlot = newHotbarSlot;

        currentItem.inventory[0] = inventoryList[(int)currentHotbarSlot].CurrentInventorySlot;

        inventoryList[(int)lastHotbarSlot].SetSelectedBackgroundActive(false);
        inventoryList[(int)currentHotbarSlot].SetSelectedBackgroundActive(true);
    }

    private void OnScrollWheel(float wheelDir)
    {
        if (Mathf.Abs(wheelDir) < scrollThreshold || Time.time - scrollTimer < scrollDelay)
            return;

        int delta = wheelDir < 0 ? -1 : 1;
        int newSlot = ((int)currentHotbarSlot + delta + inventoryList.Count) % inventoryList.Count;
        SetCurrentHotbar((HotbarSelected)newSlot);

        scrollTimer = Time.time;
    }
}

public enum HotbarSelected
{
    one,
    two,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine,
    ten,
}
