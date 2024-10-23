using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAction : PlayerAction
{
    public MoveAction(PlayerBehavior behavior) : base(behavior)
    {
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        var moveAxis = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
        _behavior.OnMovement(moveAxis);
    }
}
