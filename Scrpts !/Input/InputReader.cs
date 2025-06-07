using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, InputSystem_Actions.IPlayerActions
{
    public Action<Vector2> moveEvent;
    public Action interactEvent;
    public Action jumpEvent;
    public Action<float> sprintEvent;
    public Action<Vector2> lookEvent;


    //hotbar
    public Action hotbar1;
    public Action hotbar2;
    public Action hotbar3;
    public Action hotbar4;
    public Action hotbar5;
    public Action hotbar6;
    public Action hotbar7;
    public Action hotbar8;
    public Action hotbar9;
    public Action hotbar10;

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
        if (context.phase == InputActionPhase.Performed) hotbar1?.Invoke();
    }

    public void OnHotbar2(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar3(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar4(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar5(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar6(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar7(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar8(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar9(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbar10(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnHotbarScroll(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }


    #endregion

}