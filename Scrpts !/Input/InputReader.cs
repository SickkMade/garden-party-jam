using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, InputSystem_Actions.IPlayerActions
{
    public Action<Vector2> moveEvent;
    public Action interactEvent;
    public Action jumpEvent;
    public Action<float> sprintEvent;
    public Action<Vector2> lookEvent;


    //hotbar
    public Action<int> hotbar1;
    public Action<int> hotbar2;
    public Action<int> hotbar3;
    public Action<int> hotbar4;
    public Action<int> hotbar5;
    public Action<int> hotbar6;
    public Action<int> hotbar7;
    public Action<int> hotbar8;
    public Action<int> hotbar9;

    public Action<float> hotbarScroll;

    private InputSystem_Actions playerGameplayInput;

    void OnEnable()
    {
        if (playerGameplayInput == null)
        {
            playerGameplayInput = new();
            playerGameplayInput.Player.SetCallbacks(this);
        }

        playerGameplayInput.Player.Enable();
    }

    void OnDisable()
    {
        playerGameplayInput.Player.Disable();
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) interactEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) jumpEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprintEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    #region hotbar

    public void OnHotbar1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar1?.Invoke(1);
    }

    public void OnHotbar2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar2?.Invoke(2);
    }

    public void OnHotbar3(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar3?.Invoke(3);
    }

    public void OnHotbar4(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar4?.Invoke(4);
    }

    public void OnHotbar5(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar5?.Invoke(5);
    }

    public void OnHotbar6(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar6?.Invoke(6);
    }

    public void OnHotbar7(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar7?.Invoke(7);
    }

    public void OnHotbar8(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar8?.Invoke(8);
    }

    public void OnHotbar9(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) hotbar9?.Invoke(9);
    }


    public void OnHotbarScroll(InputAction.CallbackContext context)
    {
        hotbarScroll?.Invoke(context.ReadValue<float>());
    }

    public void OnHotbar10(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }


    #endregion

}