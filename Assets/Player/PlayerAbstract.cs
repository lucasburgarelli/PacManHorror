using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : AliveBody
{
    public float MouseSensibility = 8.5f;
    public int MouseBaseSpeed = 4;
    public bool IsPausing;

    protected readonly Transform TransformPlayerCamera;
    protected GameObject MiniMap;
    protected UIPlayer UIPlayer;
    protected int PointsLeft, TotalPoints, Lifes = 3;
    protected float MoveSpeed = 2, MouseAxisY, JumpForce = 5;

    protected PlayerAbstract(Transform transform, Rigidbody rigidbody, Animator animator, UIPlayer uiPlayer, Transform transformPlayerCamera, List<Vector3> spawnpoints, int totalPoints, GameObject miniMap) : base(transform, rigidbody, animator)
    {
        TransformPlayerCamera = transformPlayerCamera;
        UIPlayer = uiPlayer;
        Spawnpoints = spawnpoints;
        TotalPoints = totalPoints;
        MiniMap = miniMap;
        PointsLeft = TotalPoints;
        Spawn();
    }

    internal static PlayerAbstract CreateInstance(Transform transform, Rigidbody rigidbody, Animator animator, UIPlayer uiPlayer, Transform transformPlayerCamera, List<Vector3> spawnpoints, int totalPoints, GameObject miniMap)
    {
        return new Player(transform, rigidbody, animator, uiPlayer, transformPlayerCamera, spawnpoints, totalPoints, miniMap);
    }

    public abstract void CameraMove(Vector2 inputMovement);
    public abstract void Move(Vector2 moveAxis);
    public abstract void AddPoint();
    public abstract void Die();
    public abstract void OnPause(bool isPausing);

    public abstract IEnumerator SpeedPowerUp();
    public abstract IEnumerator MiniMapPowerUp();
}