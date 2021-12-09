using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownEnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTime;
    private int _pointNumber;

    private void Start()
    {
        StartCoroutine(CharacterSpawn());
    }

    private IEnumerator CharacterSpawn()
    {
        int thisPoint = _pointNumber;
        _pointNumber = Random.Range(0, _spawnPoints.Length);
        if (_pointNumber == thisPoint)
        {
            if (_pointNumber == _spawnPoints.Length - 1)
                _pointNumber = 0;
            else _pointNumber++;
        }
        Enemy currentEnemy = Instantiate(_enemys[Random.Range(0, _enemys.Length)], _spawnPoints[_pointNumber].position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(_spawnTime-0.5f,_spawnTime+0.5f));
        StartCoroutine(CharacterSpawn());
    }
}
