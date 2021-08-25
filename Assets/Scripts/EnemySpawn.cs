using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : ObjectPool
{
    [SerializeField] private Transform[] _spawnPos;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _cooldown = 1;

    private float _elapsedTime;

    private void Start()
    {
        Initialized(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _cooldown)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPos.Length);

                SetEnemy(enemy, _spawnPos[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
