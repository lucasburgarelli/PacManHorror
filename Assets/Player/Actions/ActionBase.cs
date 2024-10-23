using UnityEngine.InputSystem;

interface ActionBase
{
    public void Execute(InputAction.CallbackContext context);
}
