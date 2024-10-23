using UnityEngine;

public class MiniMapBehavior : MonoBehaviour
{
    private LayerMask _enemyMask;
    private Camera _camera;
    
    public void SetEnemyVisibility(bool visibility)
    {
        if (visibility)
            _camera.cullingMask |= _enemyMask;
        else
            _camera.cullingMask &= _enemyMask;
    }
    
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _enemyMask = LayerMask.GetMask($"Enemy");
    }

}