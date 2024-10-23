using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotateAction : PlayerAction
{
    public CameraRotateAction(PlayerBehavior behavior) : base(behavior)
    {
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        _behavior.OnCameraRotate(context.ReadValue<Vector2>());
    }
}