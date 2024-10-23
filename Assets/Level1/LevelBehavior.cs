using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    [HideInInspector] public int TotalPoins;

    public void RespawnAll()
    {
        _enemies.ForEach(enemy => enemy.GetComponent<EnemyBehavior>().GoToSpawn());
    }

    private void Awake()
    {
        GameObject.FindGameObjectsWithTag("Point").ToList().ForEach(point => {
            point.transform.rotation = Quaternion.Euler(-90, 0, 0);
            TotalPoins++;
        });
    }
}