using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "PlayerInput")]
public class PlayerInput : ScriptableObject,InputActions.IPlayerControlMapActions
{
    public event UnityAction<Vector2> onMove;
    public event UnityAction onStopMove;
    InputActions inputActions;

    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.PlayerControlMap.SetCallbacks(this);
    }
    private void OnDisable()
    {
        DisableAllInputs();
    }

    public void DisableAllInputs()
    {
        inputActions.PlayerControlMap.Disable();
    }

    public void EnablePlayerControlMap()
    {
        inputActions.PlayerControlMap.Enable();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed) // Performed:���붯����ִ��
        {
            onMove?.Invoke(context.ReadValue<Vector2>());
        }

        if(context.phase == InputActionPhase.Canceled) // Canceled:���붯��ִ�н���
        {
            onStopMove?.Invoke();
        }
    }

    

    
}