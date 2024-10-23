using UnityEngine;

public class SpeedPowerUp : PointAbstract
{
    public SpeedPowerUp(Transform transform, Rigidbody rigidbody, MeshRenderer meshRenderer) : base(transform, rigidbody, meshRenderer)
    {
        meshRenderer.material.color = Color.cyan;
    }
    public override bool TryCollect(GameObject gameObjectCollision)
    {
        var hasBeenCollected = base.TryCollect(gameObjectCollision);
        if (!hasBeenCollected) return false;
        
        gameObjectCollision.GetComponent<PlayerBehavior>().ActiveSpeedPowerUp();
        return true;
    }
}