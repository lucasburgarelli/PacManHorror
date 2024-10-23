using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private UIPlayer uiPlayer;
    [SerializeField] private GameObject miniMap;
    [SerializeField] private LevelBehavior levelBehavior;
    [SerializeField] private Transform transformCamera;
    [SerializeField] private List<Transform> spawnpoints;
    private PlayerAbstract _player;
    private Vector2 _moveAxis, _cameraMoveAxis;
    private bool _isJumpscareDone;
    public void OnMovement(Vector2 moveAxis)
    {
        _moveAxis = moveAxis;
    }

    public void OnCameraRotate(Vector2 moveAxis)
    {
        _cameraMoveAxis = moveAxis;
    }

    public void OnPause(bool isPausing)
    {
        _player.OnPause(isPausing);
    }

    public void AddPoint()
    {
        _player.AddPoint();
    }

    public void Die()
    {
        StartCoroutine(JumpscareRoutine());
        // TODO Jumscare routine

        _player.Die();
        levelBehavior.RespawnAll();
    }

    public void ActiveMiniMapPowerUp()
    {
        StartCoroutine(_player.MiniMapPowerUp());
    }

    public void ActiveSpeedPowerUp()
    {
        StartCoroutine(_player.SpeedPowerUp());
    }

    public void ChangeSensibility(float sensibility)
    {
        _player.MouseSensibility = sensibility;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collisionObject = collision.gameObject;
        if(!collisionObject.CompareTag("Portal")) return;
        
        _player.Teleport(collisionObject.GetComponent<PortalBehavior>().GetDestiny());
    }

    private void FixedUpdate()
    {
        _player.Move(_moveAxis);
        _player.CameraMove(_cameraMoveAxis);
    }

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        var spawnpointsVector = new List<Vector3>();
        spawnpoints.ForEach(spawn => spawnpointsVector.Add(spawn.position));
        
        _player = PlayerAbstract.CreateInstance(GetComponent<Transform>(), GetComponent<Rigidbody>(),
            GetComponent<Animator>(), uiPlayer, transformCamera, spawnpointsVector, levelBehavior.TotalPoins, miniMap);
    }

    private IEnumerator JumpscareRoutine()
    {
        // Play Jumpscare video

        yield return new WaitForSeconds(3);
        _isJumpscareDone = true;
    }
}
