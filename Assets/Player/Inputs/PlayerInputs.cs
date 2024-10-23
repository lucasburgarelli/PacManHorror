using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerBehavior _behavior;

    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        var action = new CameraRotateAction(_behavior);
        action.Execute(context);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        var action = new MoveAction(_behavior);
        action.Execute(context);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        var action = new PauseAction(_behavior);
        action.Execute(context);
    }

    private void Awake()
    {
        _behavior = GetComponent<PlayerBehavior>();
    }
}
