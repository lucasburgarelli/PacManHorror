using UnityEngine;

public abstract class Entity
{
    protected Transform Transform;
    protected Rigidbody Rigidbody;

    protected Entity(Transform transform, Rigidbody rigidbody)
    {
        Transform = transform;
        Rigidbody = rigidbody;
    }
}
