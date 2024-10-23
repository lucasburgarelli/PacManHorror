using UnityEngine.InputSystem;

public abstract class PlayerAction : ActionBase
{
    protected PlayerBehavior _behavior;

    protected PlayerAction(PlayerBehavior behavior)
    {
        _behavior = behavior;
    }
    
    public abstract void Execute(InputAction.CallbackContext context);
}
