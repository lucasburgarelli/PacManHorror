using UnityEngine;

public class MiniMapPowerUp : PointAbstract
{
    public MiniMapPowerUp(Transform transform, Rigidbody rigidbody, MeshRenderer meshRenderer) : base(transform, rigidbody, meshRenderer)
    {
        meshRenderer.material.color = Color.yellow;
    }
    public override bool TryCollect(GameObject gameObjectCollision)
    {
        var hasBeenCollected = base.TryCollect(gameObjectCollision);
        if (!hasBeenCollected) return false;
        
        gameObjectCollision.GetComponent<PlayerBehavior>().ActiveMiniMapPowerUp();
        return true;
    }
}