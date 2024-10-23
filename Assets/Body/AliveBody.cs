using System.Collections.Generic;
using UnityEngine;

public abstract class AliveBody : Entity
{
    public Animator Animator;
    protected int Hp;
    protected float Speed = 1;
    protected List<Vector3> Spawnpoints;

    protected AliveBody(Transform transform, Rigidbody rigidbody, Animator animator) : base(transform, rigidbody)
    {
        Animator = animator;
    }

    public void Spawn()
    {
        Transform.position = Spawnpoints[Random.Range(0, Spawnpoints.Count)];
    }
    
    public void Teleport(Vector3 destiny)
    {
        Transform.position = destiny;
    }
}
