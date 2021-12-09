using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpEnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _stayEnemys;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTime;

    private Enemy[] _spawnedEnemys = new Enemy[4];

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int i = Random.Range(0,_spawnPoints.Length);
        if (_spawnedEnemys[i] == null)
            _spawnedEnemys[i] = Instantiate(_stayEnemys[Random.Range(0, _stayEnemys.Length)], _spawnPoints[i].position, Quaternion.identity);
        else Debug.Log("NotNull");
        yield return new WaitForSeconds(Random.Range(_spawnTime-0.5f,_spawnTime+0.5f));
        StartCoroutine(SpawnEnemy());
    }
}
