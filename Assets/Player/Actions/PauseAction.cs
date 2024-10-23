using UnityEngine.InputSystem;

public class PauseAction : PlayerAction
{
    public PauseAction(PlayerBehavior behavior) : base(behavior)
    {
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        _behavior.OnPause(context.phase == InputActionPhase.Started);
    }
}