using UnityEngine;

public class PointBehavior : MonoBehaviour
{
    [SerializeField] private AudioSource _collectSound;
    private PointAbstract _point;
    
    private void Start()
    {
        _point = PointAbstract.CreateInstance(transform, GetComponent<Rigidbody>(), GetComponent<MeshRenderer>());
    }

    private void FixedUpdate()
    {
        _point.Rotate();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!_point.TryCollect(collider.gameObject)) return;
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        if (Random.Range(0, 2) == 1)
        {
            _collectSound.Play();
        }
        Destroy(gameObject, _collectSound.clip.length);
    }
}