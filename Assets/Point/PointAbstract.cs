using UnityEngine;

public abstract class PointAbstract : Entity
{
    protected MeshRenderer MeshRenderer;
    protected PointAbstract(Transform transform, Rigidbody rigidbody, MeshRenderer meshRenderer) : base(transform, rigidbody)
    {
        MeshRenderer = meshRenderer;
    }

    public static PointAbstract CreateInstance(Transform transform, Rigidbody rigidbody, MeshRenderer meshRenderer)
    {
        var random = Random.Range(0, 1200);

        return random switch
        {
            < 1190 => new Point(transform, rigidbody, meshRenderer),
            < 1198 => new MiniMapPowerUp(transform, rigidbody, meshRenderer),
            _ => new SpeedPowerUp(transform, rigidbody, meshRenderer)
        };
    }

    public void Rotate()
    {
        Transform.Rotate(Vector3.forward * Random.Range(0,5));
    }

    public virtual bool TryCollect(GameObject gameObjectCollision)
    {
        if(!gameObjectCollision.CompareTag("Player")) return false;
        
        gameObjectCollision.GetComponent<PlayerBehavior>().AddPoint();
        return true;
    }
}