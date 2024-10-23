using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private List<Transform> _spawnpoints, _waypoints;
    private Enemy _enemy;

    public void GoToSpawn()
    {
        _enemy.Spawn();
    }
    
    private void Start()
    {
        var spawnpointsVector = new List<Vector3>();
        _spawnpoints.ForEach(spawn => spawnpointsVector.Add(spawn.position));
        var waypointsVector = new List<Vector3>();
        _waypoints.ForEach(waypoint => waypointsVector.Add(waypoint.position));
        
        _enemy = Enemy.CreateInstance(transform, GetComponent<Rigidbody>(), 
            GetComponent<Animator>(), GetComponent<NavMeshAgent>(),
            _transformPlayer, spawnpointsVector, waypointsVector);
        
        StartCoroutine(_enemy.SearchPlayerRoutine());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        _enemy.TryCollisionOnPlayer(collision.gameObject);
    }
}
