using UnityEngine;

public class Portal : Entity
{
    private Vector3 _destiny;

    private Portal(Transform transform, Rigidbody rigidbody, Vector3 destiny) : base(transform, rigidbody)
    {
        var directionOffset = Transform.eulerAngles.y switch
        {
            0 => Vector3.back,
            180 => Vector3.forward,
            90 => Vector3.left,
            270 => Vector3.right
        };
        _destiny = destiny + directionOffset * 2;
    }

    public static Portal CreateInstance(Transform transform, Rigidbody rigidbody, Vector3 destiny)
    {
        return new Portal(transform, rigidbody, destiny);
    }

    public Vector3 GetDestiny() => _destiny;
}