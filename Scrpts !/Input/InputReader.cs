using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, PlayerGameplayInput.IPlayerActions
{
    public Action<Vector2> moveEvent;
    public Action interactEvent;
    public Action jumpEvent;
    public Action sprintEvent;

    private PlayerGameplayInput playerGameplayInput;

    void OnEnable()
    {
        if(playerGameplayInput == null){
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
        if(context.phase == InputActionPhase.Performed) interactEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed) jumpEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed) sprintEvent?.Invoke();
    }
}