using UnityEngine;
using UnityEngine.Serialization;

public class PortalBehavior : MonoBehaviour
{
    private Portal _portal;
    [SerializeField] private Transform transformDestinyPortal;

    public Vector3 GetDestiny() => _portal.GetDestiny();
    private void Awake()
    {
        var destiny =  transformDestinyPortal.position;
        _portal = Portal.CreateInstance(GetComponent<Transform>(), GetComponent<Rigidbody>(), destiny);
    }
}