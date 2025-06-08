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
    private float currentWheelDirection;
    private float scrollTimer;

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
    }
    void Update()
    {
        if (currentWheelDirection != 0)
        {
            ScrollHotbar();
        }
    }
    private void OnHotbar(int hotbarNum)
    {
        SetCurrentHotbar((HotbarSelected)(hotbarNum - 1));
    }
    private void SetCurrentHotbar(HotbarSelected newHotbarSlot)
    {
        lastHotbarSlot = currentHotbarSlot;
        currentHotbarSlot = newHotbarSlot;

        inventoryList[(int)lastHotbarSlot].SetSelectedBackgroundActive(false);
        inventoryList[(int)currentHotbarSlot].SetSelectedBackgroundActive(true);
    }

    private void OnScrollWheel(float wheelDir)
    {
        currentWheelDirection = wheelDir;
    }
    private void ScrollHotbar()
    {
        scrollTimer += Time.deltaTime;
        
        if (currentWheelDirection < -0.1f && scrollTimer > 0.05f)
        {
            int newSlot = (int)(currentHotbarSlot + 1) % (inventoryList.Count - 1);
            SetCurrentHotbar((HotbarSelected)newSlot);

            scrollTimer = 0;
        }
        else if (currentWheelDirection > 0.1f && scrollTimer > 0.05f)
        {
            int newSlot = (int)currentHotbarSlot - 1;
            if (newSlot < 0) newSlot = inventoryList.Count - 1;
            SetCurrentHotbar((HotbarSelected)newSlot);

            scrollTimer = 0;
        }
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
