using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : AliveBody
{
    public float Speed;
    public bool IsFollowingTarget;
    public AudioSource AudioSource;
    private NavMeshAgent _navMeshAgent;
    private Transform _transformPlayer;
    private float _followRadius = 25, _deadlyRadius = 0.5f, _stoppingDistance = 1.5f;
    private int _currentWaypoint;
    private bool _needRecalculateWaypoint;
    private List<Vector3> Waypoints;

    private Enemy(Transform transform, Rigidbody rigidbody, Animator animator, NavMeshAgent navMeshAgent, Transform transformPlayer, List<Vector3> spawnpoints, List<Vector3> waypoints) : base(transform, rigidbody, animator)
    {
        Spawnpoints = spawnpoints;
        Waypoints = waypoints;
        _navMeshAgent = navMeshAgent;
        _transformPlayer = transformPlayer;
        Spawn();
        _navMeshAgent.destination = Waypoints[0];
    }

    internal static Enemy CreateInstance(Transform transform, Rigidbody rigidbody, Animator animator, NavMeshAgent navMeshAgent, Transform transformPlayer, List<Vector3> spawnpoints, List<Vector3> waypoints)
    {
        return new Enemy(transform, rigidbody, animator, navMeshAgent, transformPlayer, spawnpoints, waypoints);
    }

    public IEnumerator SearchPlayerRoutine()
    {
        var wait = new WaitForSeconds(0.2f);
        while (true)
        {
            SearchPlayer();
            
            yield return wait;
        }
    }

    public void TryCollisionOnPlayer(GameObject possiblePlayer)
    {
        if (!possiblePlayer.CompareTag("Player")) return;

        possiblePlayer.GetComponent<PlayerBehavior>().Die();
    }
    
    private void SearchPlayer()
    {
        var isTargetNear = Vector3.Distance(Transform.position, _transformPlayer.position) < _followRadius;
        
        if (isTargetNear) _navMeshAgent.destination = _transformPlayer.position;
            
        if (!IsFollowingTarget)
        {
            IsFollowingTarget = isTargetNear;
            
            if(isTargetNear) return;
            _needRecalculateWaypoint = false;
            GoToWaypoints();
            return;
        }
        
        IsFollowingTarget = Vector3.Distance(Transform.position, _navMeshAgent.destination) < _stoppingDistance;
        if(!IsFollowingTarget) _needRecalculateWaypoint = true;
    }


    private void GoToWaypoints()
    {
        if (_needRecalculateWaypoint)
        {
            RecalculateNextWaypoint();
            _needRecalculateWaypoint = false;
            _navMeshAgent.SetDestination(Waypoints[_currentWaypoint]);
            return;
        }

        var waypointReached = Vector3.Distance(Transform.position, Waypoints[_currentWaypoint]) >= _stoppingDistance;
        _navMeshAgent.SetDestination(Waypoints[_currentWaypoint]);
        
        if (waypointReached) return;
        
        _currentWaypoint = _currentWaypoint < Waypoints.Count - 1 ? _currentWaypoint + 1 : 0;
        
        _navMeshAgent.SetDestination(Waypoints[_currentWaypoint]);
    }

    private void RecalculateNextWaypoint()
    {
        var minDistanceBetween = Vector3.Distance(Transform.position, Waypoints[0]);

        for (var index = 1; index < Waypoints.Count; index++)
        {
            var distanceToWaypoint = Vector3.Distance(Transform.position, Waypoints[index]);
            if(!(distanceToWaypoint < minDistanceBetween)) continue;
            minDistanceBetween = distanceToWaypoint;
            _currentWaypoint = index;
        }
    }
}